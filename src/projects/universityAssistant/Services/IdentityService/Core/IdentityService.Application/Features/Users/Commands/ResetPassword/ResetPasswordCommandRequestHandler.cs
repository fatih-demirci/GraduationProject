using Core.CrossCuttingConcerns.Caching;
using IdentityService.Application.Constants;
using IdentityService.Application.Features.Auths.Utils.Hashing;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Features.Users.Queries.CheckResetToken;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandRequestHandler : IRequestHandler<ResetPasswordCommandRequest, ResetPasswordResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly ICacheService _cacheService;

        public ResetPasswordCommandRequestHandler(IUserRepository userRepository, IMediator mediator, ICacheService cacheService)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _cacheService = cacheService;
        }

        public async Task<ResetPasswordResponseDto> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            CheckResetTokenQueryRequest checkResetTokenCommandRequest = new() { ResetToken = request.ResetToken, UserId = request.UserId };
            await _mediator.Send(checkResetTokenCommandRequest, cancellationToken);

            User user = (await _userRepository.GetAsync(i => i.Id == request.UserId))!;

            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _cacheService.RemoveAsync(CacheKeys.GetResetToken(user.Id.ToString()));

            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new();
        }
    }
}
