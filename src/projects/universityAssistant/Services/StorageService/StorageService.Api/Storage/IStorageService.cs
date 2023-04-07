namespace StorageService.Api.Storage
{
    public interface IStorageService
    {
        Task<bool> DeleteAsync(string fileNameforStorage);
        Task<StorageResult> UpdateAsync(string fileNameForStorage, Guid newFileNameForStorage, IFormFile formFile);
        Task<List<StorageResult>> UploadAsync(List<StorageServiceUpload> storageServiceUploads);
    }
}
