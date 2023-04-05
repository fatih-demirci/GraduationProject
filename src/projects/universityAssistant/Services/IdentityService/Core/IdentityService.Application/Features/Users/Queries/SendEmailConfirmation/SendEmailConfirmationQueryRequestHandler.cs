using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using EventBus.Base.Abstraction;
using IdentityService.Application.Constants;
using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Features.Users.Utils.EmailAuthenticator;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Languages;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Queries.SendEmailConfirmation
{
    internal class SendEmailConfirmationQueryRequestHandler : IRequestHandler<SendEmailConfirmationQueryRequest, SendEmailConfirmationResponseDto>
    {
        private readonly IEventBus _eventBus;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly ICacheService _cacheService;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<Lang> _localizer;

        public SendEmailConfirmationQueryRequestHandler(IEventBus eventBus, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ICacheService cacheService, IConfiguration configuration, IStringLocalizer<Lang> localizer)
        {
            _eventBus = eventBus;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _cacheService = cacheService;
            _configuration = configuration;
            _localizer = localizer;
        }

        public async Task<SendEmailConfirmationResponseDto> Handle(SendEmailConfirmationQueryRequest request, CancellationToken cancellationToken)
        {
            long userId = _httpContextAccessor.HttpContext.User.GetUserId();

            if (userId == 0) { throw new AuthenticationException(_localizer["ClaimsNotFound"]); }

            User user = (await _userRepository.GetAsync(i => i.Id == userId))!;

            if (user.EmailConfirmed)
            {
                throw new BusinessException(_localizer["EmailAddressAlreadyConfirmed"]);
            }

            string key = EmailAuthenticatorHelper.CreateEmailActivationKey();
            string code = EmailAuthenticatorHelper.CreateEmailActivationCode();

            int emailVerificationExpiration = _configuration.GetValue<int>("CacheOptions:EmailConfirmationExpiration");

            SendEmailIntegrationEvent @event = new(user.Email, _localizer["ConfirmEmailSubject"], @$"
                    <p>{_localizer["ConfirmEmailHello"]} {user.UserName} </p>
                    <p>{_localizer["ConfirmEmailPleaseEnterTheCode"]} : {code}</p>
                    <p>{_localizer["ConfirmEmailOrVisitTheLink"]} : <a href={_configuration.GetValue<string>("FrontEndOptions:EmailConfirmationAddress")}{key}>{_localizer["Confirm"]}</a></p>
                    <p>{_localizer["ConfirmEmailValidFor"]} {emailVerificationExpiration} {_localizer["ConfirmEmailMinutes"]}</p>
            ", "UniversityAssistantUser");
            await _eventBus.Publish(@event);
            await _cacheService.AddAsync(CacheKeys.GetEmailConfirmationKey(@event.ToEmail), key, emailVerificationExpiration);
            await _cacheService.AddAsync(CacheKeys.GetEmailConfirmationCode(@event.ToEmail), code, emailVerificationExpiration);

            return new SendEmailConfirmationResponseDto() { Message = _localizer["EmailConfirmationMailSent"] };
        }
    }
}
