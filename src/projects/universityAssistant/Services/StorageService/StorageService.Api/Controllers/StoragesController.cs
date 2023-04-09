using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageService.Api.Storage.Server;

namespace StorageService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StoragesController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("Image/GetByFileNameForStorage")]
        public IActionResult GetImageByFileNameForStorage(string fileNameForStorage)
        {
            var buffResult = _storageService.GetBytesByFileNameForStorage(fileNameForStorage);

            Response.ContentType = _storageService.GetMimeType(fileNameForStorage);
            return File(buffResult, Response.ContentType, true);
        }

        [HttpGet("Video/GetByFileNameForStorage")]
        public IActionResult GetVideoByFileNameForStorage(string fileNameForStorage)
        {
            string filePath = _storageService.GetFilePathByFileNameForStorage(fileNameForStorage);

            Response.ContentType = _storageService.GetMimeType(fileNameForStorage);
            return PhysicalFile(filePath, Response.ContentType, enableRangeProcessing: true, fileDownloadName: fileNameForStorage);
        }

        [HttpGet("Document/GetByFileNameForStorage")]
        public IActionResult GetDocumentByFileNameForStorage(string fileNameForStorage)
        {
            var buffResult = _storageService.GetBytesByFileNameForStorage(fileNameForStorage);

            Response.ContentType = _storageService.GetMimeType(fileNameForStorage);

            return File(buffResult, Response.ContentType, true);
        }
    }
}
