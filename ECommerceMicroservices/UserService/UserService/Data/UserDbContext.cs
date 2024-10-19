using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class UserDbContext:IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options ):base(options)
        {

        }
        public DbSet<UserModel> Users { get;set; }
    }
}