using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using EventBus.Base.Abstraction;
using IdentityService.Application.Constants;
using IdentityService.Application.Extensions;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Features.Users.Utils.EmailAuthenticator;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.SendEmailConfirmation
{
    internal class SendEmailConfirmationCommandRequestHandler : IRequestHandler<SendEmailConfirmationCommandRequest, SendEmailConfirmationResponseDto>
    {
        IEventBus _eventBus;
        IHttpContextAccessor _httpContextAccessor;
        IUserRepository _userRepository;
        ICacheService _cacheService;
        IConfiguration _configuration;

        public SendEmailConfirmationCommandRequestHandler(IEventBus eventBus, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ICacheService cacheService, IConfiguration configuration)
        {
            _eventBus = eventBus;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _cacheService = cacheService;
            _configuration = configuration;
        }

        public async Task<SendEmailConfirmationResponseDto> Handle(SendEmailConfirmationCommandRequest request, CancellationToken cancellationToken)
        {
            long userId = _httpContextAccessor.HttpContext.User.GetUserId();

            if (userId == 0) { throw new AuthenticationException("Claims not found"); }

            User user = (await _userRepository.GetAsync(i => i.Id == userId))!;

            if (user.EmailConfirmed)
            {
                throw new BusinessException("Email address already confirmed");
            }

            string key = EmailAuthenticatorHelper.CreateEmailActivationKey();
            string code = EmailAuthenticatorHelper.CreateEmailActivationCode();

            int emailVerificationExpiration = _configuration.GetValue<int>("CacheOptions:EmailConfirmationExpiration");

            SendEmailIntegrationEvent @event = new(user.Email, "Confirm your email", @$"
                    <p>Hello {user.UserName} </p>
                    <p>Please enter the Code : {code}</p>
                    <p>Or visit the link : <a href={request.KeyAddress}{key}>Confirm</a></p>
                    <p>Valid for {emailVerificationExpiration} minutes</p>
            ", "UniversityAssistantUser");
            await _eventBus.Publish(@event);
            await _cacheService.AddAsync(CacheKeys.GetEmailConfirmationKey(@event.ToEmail), key, emailVerificationExpiration);
            await _cacheService.AddAsync(CacheKeys.GetEmailConfirmationCode(@event.ToEmail), code, emailVerificationExpiration);

            return new SendEmailConfirmationResponseDto() { Message = "Email confirmation mail sended" };
        }
    }
}
