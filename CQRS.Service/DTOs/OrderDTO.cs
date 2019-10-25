using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service.DTOs
{
    public class OrderDTO
    {
        public string Id
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public decimal TotalPrice
        {
            get; private set;
        }
    }
}
