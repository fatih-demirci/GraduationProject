using AutoMapper;
using EventBus.Base.Abstraction;
using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IdentityService.Application.Features.Users.Commands.Update
{
    public class UserUpdateCommandRequestHandler : IRequestHandler<UserUpdateCommandRequest, UserUpdateResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public UserUpdateCommandRequestHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        async Task<UserUpdateResponseDto> IRequestHandler<UserUpdateCommandRequest, UserUpdateResponseDto>.Handle(UserUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            long userId = _httpContextAccessor.HttpContext.User.GetUserId();
            User dbUser = (await _userRepository.GetAsync(i => i.Id == userId))!;

            _mapper.Map(request, dbUser);

            await _userRepository.UnitOfWork.SaveEntitiesAsync();

            UserUpdatedIntegrationEvent userUpdatedIntegrationEvent = _mapper.Map<UserUpdatedIntegrationEvent>(dbUser);

            await _eventBus.Publish(userUpdatedIntegrationEvent);

            UserUpdateResponseDto response = _mapper.Map<User, UserUpdateResponseDto>(dbUser);
            return response;
        }
    }
}
