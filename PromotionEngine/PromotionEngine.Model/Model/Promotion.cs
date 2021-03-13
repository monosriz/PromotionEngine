using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model.Model
{
    public class Promotion
    {
        


        public  Promotion(string productID,int quantity, decimal discountPrice)
        {
            this.ProductID = productID;
            this.Quantity = quantity;
            this.DiscountPrice = discountPrice;


        }


        public Promotion(List<char> skus, decimal discountPrice)
        {
            this.SKUS = skus;
            this.DiscountPrice = discountPrice;


        }
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
