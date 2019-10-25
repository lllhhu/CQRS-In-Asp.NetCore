using CQRS.Service.DTOs;
using CQRS.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service
{
    public class OrderReadService : IOrderReadService
    {
        private readonly DbContext appDbContext;
        public OrderReadService(DbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<OrderDTO> QueryOrders(string userId)
        {
             var orders = this.appDbContext.Database.SqlQuery<OrderDTO>("select * from [Order]");

            return orders;
        }
    }
}
