namespace StorageService.Api.Storage.Server
{
    public interface IFileService
    {
        byte[] GetBytesByFileNameForStorage(string fileNameForStorage);
        string GetFilePathByFileNameForStorage(string fileNameForStorage);
        string GetMimeType(string fileName);
    }
}
