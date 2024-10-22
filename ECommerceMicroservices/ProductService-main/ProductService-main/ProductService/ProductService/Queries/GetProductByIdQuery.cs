// Path: ProductService/Queries/GetProductByIdQuery.cs
using ProductService.Models;

namespace ProductService.Queries
{
    public class GetProductByIdQuery
    {
        public int ProductId { get; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
