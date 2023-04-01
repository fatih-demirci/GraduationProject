using Core.Application.Pipelines.Authorization;
using IdentityService.Application.Constants;
using IdentityService.Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.ConfirmEmailAddress
{
    public class ConfirmEmailAddressWithKeyOrCodeRequest : IRequest<ConfirmEmailAddressWithKeyOrCodeResponseDto>
    {
        public string KeyOrCode { get; set; }
    }
}
