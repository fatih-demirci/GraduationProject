using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.StaticFiles;

namespace StorageService.Api.Storage.Server
{
    public class StorageManager : IStorageService
    {
        private readonly IHostEnvironment _hostEnvironment;

        public StorageManager(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public byte[] GetBytesByFileNameForStorage(string fileNameForStorage)
        {
            var filePath = GetFilePathByFileNameForStorage(fileNameForStorage);

            FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new(fileStream);
            byte[] buff = binaryReader.ReadBytes((int)fileStream.Length);
            return buff;
        }

        public string GetFilePathByFileNameForStorage(string fileNameForStorage)
        {
            FileType fileType = FileTypeHelper.GetFileType(fileNameForStorage);
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", fileType.ToString(), fileNameForStorage);

            if (!File.Exists(filePath))
            {
                throw new BusinessException("Dosya bulunamadı");
            }

            return filePath;
        }

        public string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
