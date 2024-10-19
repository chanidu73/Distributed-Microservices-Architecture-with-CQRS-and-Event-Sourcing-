using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace UserService.Queries
{
    public class GetUserByIdQuery:IRequest<IdentityUser>
    {
        public string Id { get;set; }
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
        
    }
}