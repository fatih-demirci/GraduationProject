using AutoMapper;
using IdentityService.Application.Features.Users.Commands.Update;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserUpdateCommandRequest, User>();
            CreateMap<User, UserUpdateResponseDto>();
        }
    }
}
