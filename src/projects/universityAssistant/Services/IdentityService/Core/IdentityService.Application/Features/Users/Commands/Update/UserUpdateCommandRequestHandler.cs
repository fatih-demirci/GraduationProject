using AutoMapper;
using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.Update
{
    public class UserUpdateCommandRequestHandler : IRequestHandler<UserUpdateCommandRequest, UserUpdateResponseDto>
    {
        IUserRepository _userRepository;
        IHttpContextAccessor _httpContextAccessor;
        IMapper _mapper;

        public UserUpdateCommandRequestHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        async Task<UserUpdateResponseDto> IRequestHandler<UserUpdateCommandRequest, UserUpdateResponseDto>.Handle(UserUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            long userId = _httpContextAccessor.HttpContext.User.GetUserId();
            User dbUser = (await _userRepository.GetAsync(i => i.Id == userId))!;

            _mapper.Map(request, dbUser);

            await _userRepository.UnitOfWork.SaveEntitiesAsync();
            UserUpdateResponseDto response = _mapper.Map<User, UserUpdateResponseDto>(dbUser);
            return response;
        }
    }
}
