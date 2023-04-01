using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using IdentityService.Application.Constants;
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

namespace IdentityService.Application.Features.Users.Commands.ConfirmEmailAddress
{
    public class ConfirmEmailAddressWithKeyOrCodeRequestHandler : IRequestHandler<ConfirmEmailAddressWithKeyOrCodeRequest, ConfirmEmailAddressWithKeyOrCodeResponseDto>
    {
        ICacheService _cacheService;
        IHttpContextAccessor _httpContextAccessor;
        IUserRepository _userRepository;

        public ConfirmEmailAddressWithKeyOrCodeRequestHandler(ICacheService cacheService, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _cacheService = cacheService;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<ConfirmEmailAddressWithKeyOrCodeResponseDto> Handle(ConfirmEmailAddressWithKeyOrCodeRequest request, CancellationToken cancellationToken)
        {
            string email = _httpContextAccessor.HttpContext.User.GetEmail() ?? throw new AuthenticationException("Claims not found");
            string? keyOrCodeInCache;
            if (request.KeyOrCode.Length == 6)
            {
                keyOrCodeInCache = await _cacheService.GetAsync<string>(CacheKeys.GetEmailConfirmationCode(email));
            }
            else
            {
                keyOrCodeInCache = await _cacheService.GetAsync<string>(CacheKeys.GetEmailConfirmationKey(email));
            }
            if (keyOrCodeInCache == null || keyOrCodeInCache != request.KeyOrCode)
            {
                throw new BusinessException("Invalid confirmation key or code");
            }
            else
            {
                User user = (await _userRepository.GetAsync(i => i.Email == email))!;
                user.EmailConfirmed = true;
                await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                await _cacheService.RemoveAsync(CacheKeys.GetEmailConfirmationKey(email));
                await _cacheService.RemoveAsync(CacheKeys.GetEmailConfirmationCode(email));
                return new ConfirmEmailAddressWithKeyOrCodeResponseDto() { Message = "Email address confirmed" };
            }
        }
    }
}
