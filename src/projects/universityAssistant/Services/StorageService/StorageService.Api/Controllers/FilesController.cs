using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageService.Api.Storage;

namespace StorageService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadAsync(IFormFileCollection formFiles)
        {
            formFiles = formFiles.Count == 0 ? Request.Form.Files : formFiles;
            List<StorageServiceUpload> storageServiceUploads = new();
            foreach (var file in formFiles)
            {
                storageServiceUploads.Add(new StorageServiceUpload(file, Guid.NewGuid()));
            }
            List<StorageResult> response = await _fileService.UploadAsync(storageServiceUploads);
            return Ok(response);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(string fileNameForStorage)
        {
            bool response = await _fileService.DeleteAsync(fileNameForStorage);
            return Ok(response);
        }
    }
}
