﻿using Core.Application.Pipelines.Authorization;
using IdentityService.Application.Constants;
using IdentityService.Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.SendEmailConfirmation
{
    public class SendEmailConfirmationCommandRequest : IRequest<SendEmailConfirmationResponseDto>
    {
        public string KeyAddress { get; set; }
    }
}