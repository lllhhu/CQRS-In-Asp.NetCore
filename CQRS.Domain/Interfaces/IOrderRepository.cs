using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);

    }
}
