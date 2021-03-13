using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model.Model
{
    public class ProductOrder
    {

        public string Id { get; set; }
        public int Quantity { get; set; }


        public ProductOrder(String id, int  quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }
    }
}
