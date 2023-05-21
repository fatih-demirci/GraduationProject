using Microsoft.AspNetCore.Http;

namespace UniversityService.Infrastructure.Storage;

public interface IFileService
{
    Task<List<StorageResult>> UploadAsync(IFormFileCollection formFiles);
}
