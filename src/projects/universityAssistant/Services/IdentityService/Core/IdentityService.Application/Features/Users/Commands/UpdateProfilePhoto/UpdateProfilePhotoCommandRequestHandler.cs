using AutoMapper;
using EventBus.Base.Abstraction;
using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Features.Users.Rules;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IdentityService.Application.Features.Users.Commands.UpdateProfilePhoto
{
    public class UpdateProfilePhotoCommandRequestHandler : IRequestHandler<UpdateProfilePhotoCommandRequest, UpdateProfilePhotoResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IEventBus _eventBus;
        private readonly IMapper _mapper;

        public UpdateProfilePhotoCommandRequestHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, UserBusinessRules userBusinessRules, IEventBus eventBus, IMapper mapper)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _userBusinessRules = userBusinessRules;
            _eventBus = eventBus;
            _mapper = mapper;
        }

        public async Task<UpdateProfilePhotoResponseDto> Handle(UpdateProfilePhotoCommandRequest request, CancellationToken cancellationToken)
        {
            string userEmail = _httpContextAccessor.HttpContext!.User.GetEmail()!;
            User user = await _userBusinessRules.UserShouldExist(userEmail);

            if (user.ProfilePhotoUrl != null)
            {
                var fileNameForStorage = user.ProfilePhotoUrl.Split("=").Last();
                DeleteFileIntegrationEvent @event = new(fileNameForStorage);
                await _eventBus.Publish(@event);
            }

            user.ProfilePhotoUrl = request.ProfilePhotoUrl;
            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            UserUpdatedIntegrationEvent userUpdatedIntegrationEvent = _mapper.Map<UserUpdatedIntegrationEvent>(user);

            await _eventBus.Publish(userUpdatedIntegrationEvent);

            return new UpdateProfilePhotoResponseDto(request.ProfilePhotoUrl);
        }
    }
}
