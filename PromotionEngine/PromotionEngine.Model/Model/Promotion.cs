using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model.Model
{
    public class Promotion
    {
        


       


       
        public string ProductID
        { get; set; }
        public List<char> SKUS
        { get; set; }
        public int Quantity
        { get; set; }
        public decimal DiscountPrice
        { get; set; }

        

    }
}
