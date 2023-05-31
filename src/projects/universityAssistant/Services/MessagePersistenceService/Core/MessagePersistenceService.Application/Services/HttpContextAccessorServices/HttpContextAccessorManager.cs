using MessagePersistenceService.Application.Constants;
using MessagePersistenceService.Application.Extensions;
using Microsoft.AspNetCore.Http;

namespace MessagePersistenceService.Application.Services.HttpContextAccessorServices;

public class HttpContextAccessorManager : IHttpContextAccessorService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextAccessorManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool CheckIfSuperAdmin()
    {
        return _httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User.Claims.Any(i => i.Value == DbRoles.SUPERADMIN);
    }

    public long GetUserId()
    {
        return _httpContextAccessor.HttpContext.User.GetUserId();
    }
}