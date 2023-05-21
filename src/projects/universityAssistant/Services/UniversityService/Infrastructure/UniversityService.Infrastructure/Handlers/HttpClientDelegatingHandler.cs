using Microsoft.AspNetCore.Http;

namespace UniversityService.Infrastructure.Handlers;

public class HttpClientDelegatingHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpClientDelegatingHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authorizationHeader = _httpContextAccessor?.HttpContext?.Request.Headers["Authorization"];

        if (!string.IsNullOrEmpty(authorizationHeader))
        {
            if (request.Headers.Contains("Authorization"))
            {
                request.Headers.Remove("Authorization");
            }
            request.Headers.Add("Authorization", authorizationHeader.Value.ToList());
        }

        return base.SendAsync(request, cancellationToken);
    }
}
