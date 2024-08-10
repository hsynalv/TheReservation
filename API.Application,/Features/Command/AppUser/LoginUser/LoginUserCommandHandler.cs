using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Abstractions.Services.Authentication;
using API.Application_.Abstractions.Token;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application_.Features.Command.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IInternalAuthentication _authService;

        public LoginUserCommandHandler(IInternalAuthentication authService)
        {
            _authService = authService;
        }


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UserNameOrEmail, request.Password, 15);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
