namespace StorageService.Api.Storage
{
    public class StorageUpload
    {
        public StorageUpload(IFormFile formFile, Guid fileNameForStorage, FileType fileType)
        {
            FormFile = formFile;
            FileNameForStorage = fileNameForStorage;
            FileType = fileType;
        }

        public IFormFile FormFile { get; set; }
        public Guid FileNameForStorage { get; set; }
        public FileType FileType { get; set; }
    }
}
