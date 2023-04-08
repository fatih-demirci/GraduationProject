using EventBus.Base.Abstraction;
using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Features.Users.Rules;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.UpdateProfilePhoto
{
    public class UpdateProfilePhotoCommandRequestHandler : IRequestHandler<UpdateProfilePhotoCommandRequest, UpdateProfilePhotoResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IEventBus _eventBus;

        public UpdateProfilePhotoCommandRequestHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, UserBusinessRules userBusinessRules, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _userBusinessRules = userBusinessRules;
            _eventBus = eventBus;
        }

        public async Task<UpdateProfilePhotoResponseDto> Handle(UpdateProfilePhotoCommandRequest request, CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.GetEmail()!;
            User user = await _userBusinessRules.UserShouldBeExist(userId);

            if (user.ProfilePhotoUrl != null)
            {
                var a = user.ProfilePhotoUrl.Split("=").Last();
                DeleteFileIntegrationEvent @event = new(a);
                await _eventBus.Publish(@event);
            }

            user.ProfilePhotoUrl = request.ProfilePhotoUrl;
            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return new UpdateProfilePhotoResponseDto(request.ProfilePhotoUrl);
        }
    }
}
