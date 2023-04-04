using Core.CrossCuttingConcerns.Exceptions;
using IdentityService.Application.Features.Auths.Utils.Hashing;
using IdentityService.Application.Languages;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer<Lang> _localizer;

        public AuthBusinessRules(IUserRepository userRepository, IStringLocalizer<Lang> localizer)
        {
            _userRepository = userRepository;
            _localizer = localizer;
        }

        public async Task EmailAddressCanNotBeDuplicated(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException(_localizer["EmailAddressExists"]);
        }

        public async Task UserNameCanNotBeDuplicated(string userName)
        {
            User? user = await _userRepository.GetAsync(u => u.UserName == userName);
            if (user != null) throw new BusinessException(_localizer["UserNameExists"]);
        }

        public async Task<User> VerifyPassword(string email, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email) ?? throw new BusinessException(_localizer["EmailAddressDoesNotExists"]);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(_localizer["PasswordIncorrect"]);
            return user;
        }
    }
}
