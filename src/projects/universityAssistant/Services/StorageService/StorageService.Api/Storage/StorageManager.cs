namespace StorageService.Api.Storage
{
    public class StorageManager : IStorageService
    {
        private readonly IStorage _storage;

        public StorageManager(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<bool> DeleteAsync(string fileNameforStorage)
        {
            FileType fileType = FileTypeHelper.GetFileType(fileNameforStorage);
            return await _storage.DeleteAsync(fileNameforStorage, fileType);
        }

        public async Task<StorageResult> UpdateAsync(string fileNameForStorage, Guid newFileNameForStorage, IFormFile formFile)
        {
            FileType fileTypeOld = FileTypeHelper.GetFileType(fileNameForStorage);
            FileType fileTypeNew = FileTypeHelper.GetFileType(formFile.FileName);
            return await _storage.UpdateAsync(fileNameForStorage, fileTypeOld, newFileNameForStorage, fileTypeNew, formFile);
        }

        public async Task<List<StorageResult>> UploadAsync(List<StorageServiceUpload> storageServiceUploads)
        {
            List<StorageUpload> storageUpload = new();
            foreach (var storageServiceUpload in storageServiceUploads)
            {
                storageUpload.Add(new StorageUpload(storageServiceUpload.FormFile, storageServiceUpload.FileNameForStorage, FileTypeHelper.GetFileType(storageServiceUpload.FormFile.FileName.ToString())));
            }
            return await _storage.UploadAsync(storageUpload);
        }
    }
}
