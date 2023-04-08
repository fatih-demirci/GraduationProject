namespace Web.ApiGateway.Responses
{
    public class StorageResult
    {
        public StorageResult(string fileNameForStorage, string url, string fileType)
        {
            FileNameForStorage = fileNameForStorage;
            URL = url;
            FileType = fileType;
        }

        public string FileNameForStorage { get; set; }
        public string URL { get; set; }
        public string FileType { get; set; }
    }
}


