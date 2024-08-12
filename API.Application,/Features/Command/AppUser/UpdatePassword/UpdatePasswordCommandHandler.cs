using API.Application_.Abstractions.Services;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application_.Features.Command.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, ResultDto>
    {
        readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ResultDto> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeFailedException("Lütfen şifreyi birebir doğrulayınız.");

            await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
            return new();
        }
    }
}
