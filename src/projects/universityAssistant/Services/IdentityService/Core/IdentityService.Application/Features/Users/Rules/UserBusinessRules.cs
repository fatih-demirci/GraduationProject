using Core.CrossCuttingConcerns.Exceptions;
using IdentityService.Application.Languages;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer<Lang> _localizer;

        public UserBusinessRules(IUserRepository userRepository, IStringLocalizer<Lang> localizer)
        {
            _userRepository = userRepository;
            _localizer = localizer;
        }

        public async Task<User> UserShouldBeExist(string email)
        {
            User? user = await _userRepository.GetAsync(i => i.Email == email) ?? throw new BusinessException(_localizer["UserShouldBeExist"]);
            return user;
        }
    }
}
