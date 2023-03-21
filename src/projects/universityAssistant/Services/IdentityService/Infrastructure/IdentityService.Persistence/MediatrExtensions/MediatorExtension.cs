using Core.Persistence.Repositories;
using IdentityService.Persistence.Contexts;
using MediatR;

namespace IdentityService.Persistence.MediatrExtensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, IdentityServiceContext identityServiceContext)
        {
            var domainEntities = identityServiceContext.ChangeTracker
                                    .Entries<Entity>()
                                    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                                    .SelectMany(x => x.Entity.DomainEvents)
                                    .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
