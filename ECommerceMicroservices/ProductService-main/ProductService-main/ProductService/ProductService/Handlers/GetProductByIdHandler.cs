using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Models;
using ProductService.Queries;
using ProductService.Repositories;

namespace ProductService.Handlers
{
    public class GetProductByIdHandler
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductModel>Handle(GetProductByIdQuery query)
        {
            return await _productRepository.GetProductByIdAsync(query.ProductId);
        }
    }
}