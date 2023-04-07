using Core.CrossCuttingConcerns.Exceptions;

namespace StorageService.Api.Storage
{
    public static class FileTypeHelper
    {
        public static FileType GetFileType(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            if (
                fileExtension.Equals(".jpg") ||
                fileExtension.Equals(".png") ||
                fileExtension.Equals(".jpeg") ||
                fileExtension.Equals(".gif"))
            {
                return FileType.Image;
            }
            else if (
                   fileExtension.Equals(".mp4") ||
                   fileExtension.Equals(".webm") ||
                   fileExtension.Equals(".ogg") ||
                   fileExtension.Equals(".3gp") ||
                   fileExtension.Equals(".mpeg4"))
            {
                return FileType.Video;
            }
            else if (
                    fileExtension.Equals(".pdf") ||
                    fileExtension.Equals(".ppt") ||
                    fileExtension.Equals(".pptx") ||
                    fileExtension.Equals(".docx") ||
                    fileExtension.Equals(".doc") ||
                    fileExtension.Equals(".txt"))
            {
                return FileType.Document;
            }
            throw new BusinessException("Desteklemeyen dosya türü");
        }
    }
}
