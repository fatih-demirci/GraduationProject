using Core.CrossCuttingConcerns.Exceptions;
using IdentityService.Application.Features.Auths.Utils.Hashing;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailAddressCanNotBeDuplicated(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Email address exists");
        }

        public async Task<User> VerifyPassword(string email, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email) ?? throw new BusinessException("Email address does not exists.");
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("Password incorrect");
            return user;
        }
    }
}
