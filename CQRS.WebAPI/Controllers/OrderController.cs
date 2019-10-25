using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Service;
using CQRS.Service.CommandHandlers;
using CQRS.Service.Commands;
using CQRS.Service.DTOs;
using CQRS.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICommandBus commandBus;
        private readonly IOrderReadService orderReadService;
        public OrderController(ICommandBus commandBus, IOrderReadService orderReadService)
        {
            this.commandBus = commandBus;
            this.orderReadService = orderReadService;
        }
        [HttpGet]
        public ActionResult<Result> Get()
        {
            var cmd = new CreateOrderCommand();
            cmd.BuyerId = "US-4985649795656556526";
            cmd.BuyerName = "tianka";

            cmd.Products = new List<ProductDTO>();
            cmd.Products.Add(new ProductDTO { Id="00001",ProductName = "小米手机",Price = 2000});
            cmd.Products.Add(new ProductDTO { Id = "00001", ProductName = "小米手机", Price = 2000 });
            cmd.Products.Add(new ProductDTO { Id = "00002", ProductName = "联想电脑", Price = 4000 });

            this.commandBus.Send(cmd);

            

            return cmd.Result;
        }


        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<OrderDTO>> GetOrderList()
        {
            var orders = this.orderReadService.QueryOrders("081a4630-8df9-43c5-935b-8dcd3ebf6386");

            return orders;
        }
    }
}