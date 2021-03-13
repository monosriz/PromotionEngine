using PromotionEngine.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionEngine.Model
{
    public class PriceCalculatorService
    {


        public bool Status { get; set; }



        public decimal GetTotalPrice(List<Product> products, List<Promotion> promotions, List<ProductOrder> productsorders)
        {
            decimal totalCost = 0;
        
            products.All(p => {

            totalCost+= SingleProductPrice(p, productsorders.Count(PO => PO.Id == p.Id), promotions.Find(pm => pm.ProductID == p.Id));
                return true;
            });


            return totalCost;


        }


        private decimal SingleProductPrice(Product product, int noofProduct, Promotion promotion)
        {
           
            if(promotion!=null)
                return (noofProduct / promotion.Quantity) * promotion.DiscountPrice + (noofProduct % promotion.Quantity * product.Price);
            else
                return noofProduct * product.Price;
          
        }

        private void MutipleProductPrice()
        {

        }


    }
}
