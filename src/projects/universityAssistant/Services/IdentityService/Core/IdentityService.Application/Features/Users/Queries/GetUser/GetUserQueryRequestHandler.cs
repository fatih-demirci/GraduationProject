using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryRequestHandler : IRequestHandler<GetUserQueryRequest, GetUserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetUserQueryRequestHandler(IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetUserResponseDto> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            long userId = _contextAccessor.HttpContext.User.GetUserId();
            GetUserResponseDto user = (await _userRepository.GetAsync<GetUserResponseDto>(i => i.Id == userId))!;
            return user;
        }
    }
}
