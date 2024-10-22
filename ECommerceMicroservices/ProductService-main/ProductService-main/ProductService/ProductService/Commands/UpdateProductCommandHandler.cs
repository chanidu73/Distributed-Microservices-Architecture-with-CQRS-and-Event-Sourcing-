using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using ProductService.Repositories;

namespace ProductService.Commands
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand ,bool>
    {
        private readonly IProductRepository _productRepository;

    
        public async Task<bool>Handle(UpdateProductCommand request , CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if(product ==null)return false;
            product.Name = request.Name;
            product.Price = request.Price;

            await _productRepository.UpdateProductAsync(product);
            return true;
        }
    }

}