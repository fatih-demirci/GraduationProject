using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Dtos
{
    public class UpdateProfilePhotoResponseDto
    {
        public UpdateProfilePhotoResponseDto(string profilePhotoUrl)
        {
            ProfilePhotoUrl = profilePhotoUrl;
        }

        public string ProfilePhotoUrl { get; set; }
    }
}
