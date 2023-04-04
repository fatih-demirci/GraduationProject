using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using IdentityService.Application.Constants;
using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Languages;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.ConfirmEmailAddress
{
    public class ConfirmEmailAddressWithKeyOrCodeRequestHandler : IRequestHandler<ConfirmEmailAddressWithKeyOrCodeRequest, ConfirmEmailAddressWithKeyOrCodeResponseDto>
    {
        private readonly ICacheService _cacheService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer<Lang> _localizer;

        public ConfirmEmailAddressWithKeyOrCodeRequestHandler(ICacheService cacheService, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IStringLocalizer<Lang> localizer)
        {
            _cacheService = cacheService;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _localizer = localizer;
        }

        public async Task<ConfirmEmailAddressWithKeyOrCodeResponseDto> Handle(ConfirmEmailAddressWithKeyOrCodeRequest request, CancellationToken cancellationToken)
        {
            string email = _httpContextAccessor.HttpContext.User.GetEmail() ?? throw new AuthenticationException(_localizer["ClaimsNotFound"]);
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
                throw new BusinessException(_localizer["InvalidConfirmationKeyOrCode"]);
            }
            else
            {
                User user = (await _userRepository.GetAsync(i => i.Email == email))!;
                user.EmailConfirmed = true;
                await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                await _cacheService.RemoveAsync(CacheKeys.GetEmailConfirmationKey(email));
                await _cacheService.RemoveAsync(CacheKeys.GetEmailConfirmationCode(email));
                return new ConfirmEmailAddressWithKeyOrCodeResponseDto() { Message = _localizer["EmailAddressConfirmed"] };
            }
        }
    }
}
