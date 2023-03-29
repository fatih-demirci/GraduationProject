using IdentityService.Application.Features.Auths.Dtos;
using IdentityService.Application.Features.Auths.Queries.Login;
using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Application.Services.AuthServices;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, LoginResponseDto>
    {
        IUserRepository _userRepository;
        IAuthService _authService;
        IMediator _mediator;

        public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, IMediator mediator)
        {
            _userRepository = userRepository;
            _authService = authService;
            _mediator = mediator;
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

            return await _mediator.Send(new LoginQueryRequest() { Email = request.Email, IpAddress = request.IpAddress, Password = request.Password }, cancellationToken);
        }
    }
}
