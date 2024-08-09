using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application_.Features.Command.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entity.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entity.Identity.AppUser> _signInManager;

        public LoginUserCommandHandler(SignInManager<Domain.Entity.Identity.AppUser> signInManager, UserManager<Domain.Entity.Identity.AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.Identity.AppUser user =  await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new UserNotFoundException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);


            return new();

        }
    }
}
