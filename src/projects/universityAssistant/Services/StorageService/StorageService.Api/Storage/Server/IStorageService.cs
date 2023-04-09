namespace StorageService.Api.Storage.Server
{
    public interface IStorageService
    {
        byte[] GetBytesByFileNameForStorage(string fileNameForStorage);
        string GetFilePathByFileNameForStorage(string fileNameForStorage);
        string GetMimeType(string fileName);
    }
}
