using Microsoft.AspNetCore.Http;

namespace MessagePersistenceService.Infrastructure.Storage;

public interface IFileService
{
    Task<List<StorageResult>> UploadAsync(IFormFileCollection formFiles);
}
