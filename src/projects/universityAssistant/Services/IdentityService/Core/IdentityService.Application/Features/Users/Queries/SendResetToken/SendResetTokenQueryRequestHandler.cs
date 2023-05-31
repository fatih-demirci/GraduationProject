using Core.CrossCuttingConcerns.Caching;
using EventBus.Base.Abstraction;
using IdentityService.Application.Constants;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Features.Users.Rules;
using IdentityService.Application.Features.Users.Utils.ResetTokenAuthenticator;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Languages;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;

namespace IdentityService.Application.Features.Users.Queries.SendResetToken
{
    public class SendResetTokenQueryRequestHandler : IRequestHandler<SendResetTokenQueryRequest, SendResetTokenResponseDto>
    {
        private readonly UserBusinessRules _userBusinessRules;
        private readonly ICacheService _cacheService;
        private readonly IEventBus _eventBus;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<Lang> _localizer;

        public SendResetTokenQueryRequestHandler(UserBusinessRules userBusinessRules, ICacheService cacheService, IEventBus eventBus, IConfiguration configuration, IStringLocalizer<Lang> localizer)
        {
            _userBusinessRules = userBusinessRules;
            _cacheService = cacheService;
            _eventBus = eventBus;
            _configuration = configuration;
            _localizer = localizer;
        }

        public async Task<SendResetTokenResponseDto> Handle(SendResetTokenQueryRequest request, CancellationToken cancellationToken)
        {
            User user = await _userBusinessRules.UserShouldExist(request.Email);

            string token = ResetTokenAuthenticatorHelper.CreateResetToken();
            ResetToken resetToken = new(user.Id, token);

            int emailVerificationExpiration = _configuration.GetValue<int>("CacheOptions:ResetTokenExpiration");
            await _cacheService.AddAsync(CacheKeys.GetResetToken(user.Id.ToString()), resetToken, emailVerificationExpiration);

            SendEmailIntegrationEvent @event = new(user.Email, _localizer["ResetTokenSubject"], @$"{_localizer["ResetTokenMessage"]} : <a href={_configuration.GetValue<string>("FrontEndOptions:ResetTokenAddress")}{user.Id}/{resetToken.Token}>{_localizer["ResetMyPassword"]}</a>", "UniversityAssistantUser");

            await _eventBus.Publish(@event);

            return new SendResetTokenResponseDto { Message = _localizer["ResetTokenSent"] };
        }
    }
}
