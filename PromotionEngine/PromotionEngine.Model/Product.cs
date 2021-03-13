using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model
{
    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }


        public Product(String id, decimal price)
        {
            this.Id = id;
            this.Price = price;
        }
    }
}
