using IdentityService.Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Queries.SendEmailConfirmation
{
    public class SendEmailConfirmationQueryRequest : IRequest<SendEmailConfirmationResponseDto>
    {
    }
}
