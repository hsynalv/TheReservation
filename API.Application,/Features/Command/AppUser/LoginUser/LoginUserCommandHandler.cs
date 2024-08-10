using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Abstractions;
using API.Application_.DTOs;
using API.Application_.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application_.Features.Command.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entity.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entity.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(SignInManager<Domain.Entity.Identity.AppUser> signInManager, UserManager<Domain.Entity.Identity.AppUser> userManager, ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.Identity.AppUser user =  await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new UserNotFoundException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);


            if (result.Succeeded) //Authentication başarılı!
            {
                //.... Yetkileri belirlememiz gerekiyor!
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };
            }


            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Kullanıcı adı veya şifre hatalı..."
            //};
            throw new AuthenticationErrorException();

        }
    }
}
