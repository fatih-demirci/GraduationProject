namespace Web.ApiGateway.Requests
{
    public class UpdateProfilePhotoCommandRequest
    {
        public UpdateProfilePhotoCommandRequest(string profilePhotoUrl)
        {
            ProfilePhotoUrl = profilePhotoUrl;
        }

        public string ProfilePhotoUrl { get; set; }
    }
}
