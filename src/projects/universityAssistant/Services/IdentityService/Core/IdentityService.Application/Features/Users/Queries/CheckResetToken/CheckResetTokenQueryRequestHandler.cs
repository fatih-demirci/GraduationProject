using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using IdentityService.Application.Constants;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Languages;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Queries.CheckResetToken
{
    public class CheckResetTokenQueryRequestHandler : IRequestHandler<CheckResetTokenQueryRequest>
    {
        private readonly ICacheService _cacheService;
        private readonly IStringLocalizer<Lang> _localizer;

        public CheckResetTokenQueryRequestHandler(ICacheService cacheService, IStringLocalizer<Lang> localizer)
        {
            _cacheService = cacheService;
            _localizer = localizer;
        }

        public async Task Handle(CheckResetTokenQueryRequest request, CancellationToken cancellationToken)
        {
            ResetToken? resetToken = await _cacheService.GetAsync<ResetToken>(CacheKeys.GetResetToken(request.UserId.ToString()));
            if (resetToken == null || resetToken.Token != request.ResetToken)
            {
                throw new BusinessException(_localizer["InvalidResetToken"]);
            }
        }
    }
}
