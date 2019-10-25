using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service.Commands
{
    public class CreateOrderCommand :Command,ICommand
    {
        public string Title { get; set; }
        public string BuyerId { get; set; }
        public string BuyerName { get; set; }

        public List<ProductDTO> Products { get; set; }

    }

    public class ProductDTO
    {
        public string Id
        {
            get;set;
        }

        public string ProductName
        {
            get;set;
        }

        public decimal Price
        {
            get;set;
        }

    }
}
