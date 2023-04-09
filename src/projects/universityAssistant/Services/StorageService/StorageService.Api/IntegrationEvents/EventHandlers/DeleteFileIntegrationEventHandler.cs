using EventBus.Base.Abstraction;
using StorageService.Api.IntegrationEvents.Events;
using StorageService.Api.Storage;
using StorageService.Api.Storage.Server;

namespace StorageService.Api.IntegrationEvents.EventHandlers
{
    public class DeleteFileIntegrationEventHandler : IIntegrationEventHandler<DeleteFileIntegrationEvent>
    {
        private readonly IServiceProvider _serviceProvider;

        public DeleteFileIntegrationEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(DeleteFileIntegrationEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();
            await scope.ServiceProvider.GetRequiredService<IFileService>().DeleteAsync(@event.FileNameForStorage);
        }
    }
}
