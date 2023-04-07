using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageService.Api.Storage;
using StorageService.Api.Storage.Server;

namespace StorageService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly IStorageService _storageService;
        private readonly IFileService _fileService;

        public StoragesController(IStorageService storageService, IFileService fileService)
        {
            _storageService = storageService;
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
            List<StorageResult> response = await _storageService.UploadAsync(storageServiceUploads);
            return Ok(response);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(string fileNameForStorage)
        {
            bool response = await _storageService.DeleteAsync(fileNameForStorage);
            return Ok(response);
        }

        [HttpGet("Image/GetByFileNameForStorage")]
        public IActionResult GetImageByFileNameForStorage(string fileNameForStorage)
        {
            var buffResult = _fileService.GetBytesByFileNameForStorage(fileNameForStorage);

            Response.ContentType = _fileService.GetMimeType(fileNameForStorage);
            return File(buffResult, Response.ContentType, true);
        }

        [HttpGet("Video/GetByFileNameForStorage")]
        public IActionResult GetVideoByFileNameForStorage(string fileNameForStorage)
        {
            string filePath = _fileService.GetFilePathByFileNameForStorage(fileNameForStorage);

            Response.ContentType = _fileService.GetMimeType(fileNameForStorage);
            return PhysicalFile(filePath, Response.ContentType, enableRangeProcessing: true, fileDownloadName: fileNameForStorage);
        }

        [HttpGet("Document/GetByFileNameForStorage")]
        public IActionResult GetDocumentByFileNameForStorage(string fileNameForStorage)
        {
            var buffResult = _fileService.GetBytesByFileNameForStorage(fileNameForStorage);

            Response.ContentType = _fileService.GetMimeType(fileNameForStorage);

            return File(buffResult, Response.ContentType, true);
        }
    }
}
