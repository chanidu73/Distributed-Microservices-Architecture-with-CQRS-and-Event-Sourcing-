using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Commands;
using UserService.Queries;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator =mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult>CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result)
            {
                return BadRequest("Failed To Create user");
            }
            else
                return Ok("User Created successfully");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            if(user== null)return NotFound("No User Called That You enterd Id");
            return Ok(user);
            
        }
    }
}


/*

{
  "name": "JohnDoe",
  "email": "johndoe@example.com",
  "password": "B7@kW9z#"
}


*/