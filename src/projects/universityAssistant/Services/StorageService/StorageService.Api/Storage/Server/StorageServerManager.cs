namespace StorageService.Api.Storage.Server
{
    public class StorageServerManager : IStorage
    {
        private readonly IHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public StorageServerManager(IHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public async Task<bool> DeleteAsync(string fileNameforStorage, FileType fileType)
        {
            try
            {
                var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", fileType.ToString(), fileNameforStorage);
                File.Delete(filePath);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<StorageResult> UpdateAsync(string fileNameForStorage, FileType fileTypeOld, Guid newFileNameForStorage, FileType fileTypeNew, IFormFile formFile)
        {
            await DeleteAsync(fileNameForStorage, fileTypeOld);
            List<StorageUpload> storageUploads = new() { new StorageUpload(formFile, newFileNameForStorage, fileTypeNew) };
            List<StorageResult> result = await UploadAsync(storageUploads);
            return result.First();
        }

        public async Task<List<StorageResult>> UploadAsync(List<StorageUpload> storageUploads)
        {
            var fileUploadResults = new List<StorageResult>();

            foreach (var storageUpload in storageUploads)
            {
                if (storageUpload.FormFile?.Length > 0)
                {
                    try
                    {
                        string uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", storageUpload.FileType.ToString());
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        string uniqueFileName = $"{storageUpload.FileNameForStorage}{Path.GetExtension(storageUpload.FormFile.FileName)}";
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (FileStream fileStream = new(filePath, FileMode.Create))
                        {
                            await storageUpload.FormFile.CopyToAsync(fileStream);
                            await fileStream.FlushAsync();
                        }
                        string url = $"{_configuration.GetValue<string>("Gateway:Address")}{storageUpload.FileType}/GetByFileNameForStorage?fileNameForStorage={uniqueFileName}";
                        StorageResult fileUploadResult = new(uniqueFileName, url, storageUpload.FileType.ToString());

                        fileUploadResults.Add(fileUploadResult);
                    }
                    catch (Exception)
                    {

                    }

                }
            }

            return await Task.FromResult(fileUploadResults);
        }
    }
}
