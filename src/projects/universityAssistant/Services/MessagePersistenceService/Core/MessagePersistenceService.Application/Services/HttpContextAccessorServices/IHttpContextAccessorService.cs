namespace MessagePersistenceService.Application.Services.HttpContextAccessorServices;

public interface IHttpContextAccessorService
{
    bool CheckIfSuperAdmin();
    long GetUserId();
}