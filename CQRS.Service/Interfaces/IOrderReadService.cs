using CQRS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service.Interfaces
{
    public interface IOrderReadService
    {
        List<OrderDTO> QueryOrders(string userId);
    }
}
