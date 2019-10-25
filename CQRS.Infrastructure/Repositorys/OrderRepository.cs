using CQRS.Domain;
using CQRS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Infrastructure.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Save(Order order)
        {
            this.appDbContext.Add(order);
            this.appDbContext.SaveChanges();
        }
    }
}
