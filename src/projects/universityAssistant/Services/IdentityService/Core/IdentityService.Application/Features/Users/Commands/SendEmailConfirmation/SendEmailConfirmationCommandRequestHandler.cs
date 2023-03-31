using Core.CrossCuttingConcerns.Caching;
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
using Microsoft.Extensions.Caching.Distributed;
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

        public SendEmailConfirmationCommandRequestHandler(IEventBus eventBus, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ICacheService cacheService)
        {
            _eventBus = eventBus;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _cacheService = cacheService;
        }

        public async Task<SendEmailConfirmationResponseDto> Handle(SendEmailConfirmationCommandRequest request, CancellationToken cancellationToken)
        {
            long userId = _httpContextAccessor.HttpContext.User.GetUserId();
            User user = (await _userRepository.GetAsync(i => i.Id == userId))!;

            string key = EmailAuthenticatorHelper.CreateEmailActivationKey();
            string code = EmailAuthenticatorHelper.CreateEmailActivationCode();

            SendEmailIntegrationEvent @event = new(user.Email, "Confirm your email", @$"
            <html>
                <body>
                    <p>Hello {user.UserName} </p>
                    <p>Please enter the Code : {code}</p>
                    <p>Or visit the link : {request.KeyAddress}{key}</p>
                </body>
            </html>
            ");
            await _eventBus.Publish(@event);

            await _cacheService.AddAsync(CacheKeys.GetEmailConfirmationKey(@event.Email), key, 1);
            await _cacheService.AddAsync(CacheKeys.GetEmailConfirmationCode(@event.Email), code, 1);

            return new SendEmailConfirmationResponseDto() { Message = "Email confirmation mail sended" };
        }
    }
}
