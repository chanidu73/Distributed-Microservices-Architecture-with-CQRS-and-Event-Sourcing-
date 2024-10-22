using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ProductService.Models;
using ProductService.Repositories;

namespace ProductService.Commands
{
    public class CreateProductCommand:IRequest<ProductModel>
    {
        public string Name { get;set; }
        public decimal Price { get;set; }
        public string Description { get;set; }
        public string Category { get;set; }
    }
    public class CreateProductCommandHandler :IRequestHandler<CreateProductCommand , ProductModel>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel>Handle(CreateProductCommand request , CancellationToken cancellationToken)
        {
                var product = new ProductModel
                {
                    ProductId = Guid.NewGuid(),
                    Name = request.Name,
                    Price = request.Price,
                    Description = request.Description,
                    Category = request.Category,
                    CreatedDate = DateTime.UtcNow
                };   
                await _productRepository.AddProductAsync(product);
                return product; 

        }
   
    }
}