namespace StorageService.Api.Storage
{
    public interface IFileService
    {
        Task<bool> DeleteAsync(string fileNameforStorage);
        Task<StorageResult> UpdateAsync(string fileNameForStorage, Guid newFileNameForStorage, IFormFile formFile);
        Task<List<StorageResult>> UploadAsync(List<StorageServiceUpload> storageServiceUploads);
    }
}
