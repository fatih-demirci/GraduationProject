using AutoMapper;
using EventBus.Base.Abstraction;
using IdentityService.Application.Features.Auths.Dtos;
using IdentityService.Application.Features.Auths.Queries.Login;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Services.AuthServices;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Features.Auths.Commands.Register
{
    public class RegisterCommandRequestHandler : IRequestHandler<RegisterCommandRequest, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        public RegisterCommandRequestHandler(IUserRepository userRepository, IAuthService authService, IMediator mediator, IMapper mapper, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<LoginResponseDto> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var userToBeAdded = new User(request.Email, request.Password, request.IpAddress)
            {
                Email = request.Email,
                AuthenticatorType = Domain.Enums.AuthenticatorType.None,
                UserName = request.UserName,
                Status = true,
            };
            _userRepository.Add(userToBeAdded);
            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            UserAddedIntegrationEvent userAddedIntegrationEvent = _mapper.Map<UserAddedIntegrationEvent>(userToBeAdded);

            await _eventBus.Publish(userAddedIntegrationEvent);

            return await _mediator.Send(new LoginQueryRequest() { Email = request.Email, IpAddress = request.IpAddress, Password = request.Password }, cancellationToken);
        }
    }
}
