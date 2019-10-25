using System;
using System.Collections.Generic;

namespace CQRS.Domain
{
    public class OrderItem
    {
        public OrderItem(Product product)
        {
            this.Product = product;
            this.Id = Guid.NewGuid().ToString();
            this.IncrementQuantity();
        }


        public OrderItem()
        {

        }

        public string Id
        {
            get; private set;
        }

        public Product Product
        {
            get; private set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        {
            get; private set;
        }

        public void IncrementQuantity(int quantity = 1)
        {
            if (quantity <= 0) throw new Exception("订单项数量不能小于0");
            this.Quantity = this.Quantity + quantity;
        }

        public virtual Order Order
        {
            get; private set;
        }
    }
}
