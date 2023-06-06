namespace MessageOnlineService.Api.Extensions.Auth;

public class TokenOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecurityKey { get; set; }
}
