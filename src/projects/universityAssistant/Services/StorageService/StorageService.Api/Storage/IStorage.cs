namespace StorageService.Api.Storage
{
    public interface IStorage
    {
        Task<bool> DeleteAsync(string fileNameforStorage, FileType fileType);
        Task<StorageResult> UpdateAsync(string fileNameForStorage, FileType fileTypeOld, Guid newFileNameForStorage, FileType fileTypeNew, IFormFile formFile);
        Task<List<StorageResult>> UploadAsync(List<StorageUpload> storageUploads);
    }
}
