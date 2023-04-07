namespace StorageService.Api.Storage
{
    public class StorageServiceUpload
    {
        public StorageServiceUpload(IFormFile formFile, Guid fileNameForStorage)
        {
            FormFile = formFile;
            FileNameForStorage = fileNameForStorage;
        }

        public IFormFile FormFile { get; set; }
        public Guid FileNameForStorage { get; set; }
    }
}
