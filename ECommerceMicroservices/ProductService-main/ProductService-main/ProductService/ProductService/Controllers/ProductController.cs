using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Commands;
using ProductService.Data;
using ProductService.Queries;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ProductDbContext _context;
        public ProductController(IMediator mediator , ProductDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById) , new { id = result.ProductId} , result);
            // return Ok();

        }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetProductById(Guid id)
        {
            // var result = await _mediator.Send(new GetProductByIdQuery(id));
            // return Ok(result);
            var product = await _context.Products.FindAsync(id);
            if(product==null)return NotFound("There is No Product Called Input");
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult>GetAllProducts()
        {
            var query = await _context.Products.ToListAsync();
            return Ok(query);
        }
        []
    }
} 