using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace UserService.Commands
{
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand ,bool>

    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(CreateUserCommand request , CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.Name,
                Email = request.Email
            };
            var result = await _userManager.CreateAsync(user ,request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            foreach(var err in result.Errors)
            {
                Console.WriteLine(err.Description);
            }
            return false;
        }
    }
}