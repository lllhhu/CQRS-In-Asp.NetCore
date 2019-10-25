using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Domain
{
    /// <summary>
    /// 在Order上下文，是一个值对象
    /// </summary>
    public class Product
    {
        public Product()
        {

        }

        public Product(string id, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name) || price < 0)
            {
                throw new ArgumentNullException("参数不能为空");
            }

            this.Id = id;
            this.Name = name;
            this.Price = price;

        }

        /// <summary>
        /// 供应商商品Id
        /// </summary>
        public string Id
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public decimal Price
        {
            get; private set;
        }


    }

}
