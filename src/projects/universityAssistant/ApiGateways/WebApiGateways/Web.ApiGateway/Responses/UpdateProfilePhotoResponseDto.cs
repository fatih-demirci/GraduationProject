namespace Web.ApiGateway.Responses
{
    public class UpdateProfilePhotoResponseDto
    {
        public string ProfilePhotoUrl { get; set; }

        public UpdateProfilePhotoResponseDto(string profilePhotoUrl)
        {
            ProfilePhotoUrl = profilePhotoUrl;
        }
    }
}
