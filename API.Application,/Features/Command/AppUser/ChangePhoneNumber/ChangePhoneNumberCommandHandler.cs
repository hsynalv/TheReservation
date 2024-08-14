using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Abstractions.Services;
using API.Application_.DTOs;
using MediatR;

namespace API.Application_.Features.Command.AppUser.ChangePhoneNumber
{
    public class ChangePhoneNumberCommandHandler : IRequestHandler<ChangePhoneNumberCommandRequest, ResultDto>
    {
        readonly IUserService _userService;

        public ChangePhoneNumberCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResultDto> Handle(ChangePhoneNumberCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userService.GetUser(request.UserName);
            var result = await _userService.ChangePhoneNumber(user, request.PhoneNumber);
            return new() { Succeeded = result };
        }
    }
}
