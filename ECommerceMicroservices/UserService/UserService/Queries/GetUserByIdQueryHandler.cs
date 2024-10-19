using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace UserService.Queries
{
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IdentityUser>
{
    private readonly UserManager<IdentityUser> _userManager;

    public GetUserByIdQueryHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        return user;
    }
}
}