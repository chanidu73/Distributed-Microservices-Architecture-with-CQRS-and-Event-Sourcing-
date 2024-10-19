using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UserService.Models
{
    public class UserModel:IdentityUser
    {
        public int UserId { get;set; }
        public string Name { get;set; }
        public string Email { get;set; }
        public string PasswordHash { get;set; }

    }
}