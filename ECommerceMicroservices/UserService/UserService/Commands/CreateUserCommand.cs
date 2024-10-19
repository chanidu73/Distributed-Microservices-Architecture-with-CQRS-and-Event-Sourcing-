using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UserService.Commands
{
    public class CreateUserCommand:IRequest<bool>
    {
        public string Name { get;set ;}
        public string Email { get;set; }
        public string Password { get;set; }
        public CreateUserCommand(string name , string email , string password)
        {
            Name =name;
            Email = email;
            Password = password;
        }
    }
}