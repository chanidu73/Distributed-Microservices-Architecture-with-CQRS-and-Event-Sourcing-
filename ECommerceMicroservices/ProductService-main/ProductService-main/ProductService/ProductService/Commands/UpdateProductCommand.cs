using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ProductService.Commands
{
    public class UpdateProductCommand:IRequest<bool>
    {
        public int ProductId { get;set; }
        public string Name { get;set; }
        public decimal Price { get;set; }
        // public int StockQuatity { get;set; }
    }
}