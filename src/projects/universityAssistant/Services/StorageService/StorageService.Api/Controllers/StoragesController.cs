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
        private readonly IFileService _fileService;

        public StoragesController(IFileService fileService)
        {
            _fileService = fileService;
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
