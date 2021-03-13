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

           if(productsorders.Find(PO => PO.Id == p.Id)!=null)
            { 
            totalCost+= SingleProductPrice(p, productsorders.Find(PO => PO.Id == p.Id).Quantity, promotions.Find(pm => pm.ProductID == p.Id));
                return true;
            }
                return false;
               
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
