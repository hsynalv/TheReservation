using API.Application_.Features.Command.AppUser.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Abstractions.Services;

namespace API.Application_.Features.Command.AppUser.ChangePassword
{
    public class ChangePasswordCommandHandler: IRequestHandler<ChangePasswordCommandRequest, ChangePasswordCommandResponse>
    {
        readonly IUserService _userService;

        public ChangePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userService.GetUser(request.Username);
            bool result = await _userService.ChangePassword(user, request.CurrentPassword, request.NewPassword);
            if (result == false)
                throw new Exception("Şifre değiştirilirken bir hata meydana geldi");

            return new() { Succeeded = true };
        }
    }
}
