using CQRS.Domain;
using CQRS.Domain.Interfaces;
using CQRS.Service.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Execute(CreateOrderCommand command)
        {
            try
            {
                var order = new Order(command.BuyerId, command.BuyerName);
                foreach (var pro in command.Products)
                {
                    order.AddItem(new Product(pro.Id, pro.ProductName, pro.Price));
                }

                this.orderRepository.Save(order);

                command.Result = new Result();
            }
            catch (Exception ex)
            {
                command.Result = new Result(500,ex.ToString());
            }
        }
    }
}
