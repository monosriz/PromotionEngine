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
        public string Message { get; set; }


        public decimal GetTotalPrice(List<Product> products, List<Promotion> promotions, List<ProductOrder> productsorders)
        {
            decimal totalCost = 0;

            try
            { 
            promotions.All(pm =>
            {

                if (pm.ProductIDs != null)
                {
                    totalCost += MultiProductPrice(products, productsorders.FindAll(po => pm.ProductIDs.Any(b => po.Id == b)), pm.DiscountPrice);

                    productsorders.RemoveAll(po => pm.ProductIDs.Any(b => po.Id == b));

                }

                return true;
            });



            products.All(p =>
            {

                if (productsorders.Find(PO => PO.Id == p.Id) != null)
                {


                    totalCost += SingleProductPrice(p, productsorders.Find(PO => PO.Id == p.Id).Quantity, promotions.Find(pm => pm.ProductID == p.Id));
                    productsorders.Remove(productsorders.Find(PO => PO.Id == p.Id));


                }
                return true;

            });


                Status = true;
                Message = "Prduct calculate Succesfully.";
                

            return totalCost;
          }
            catch (Exception ex)
            {
                Status = false;
                Message = ex.Message;
                return 0;
            }

        }


        private decimal SingleProductPrice(Product product, int noofProduct, Promotion promotion)
        {

          
            if (promotion != null)
                return (noofProduct / promotion.Quantity) * promotion.DiscountPrice + (noofProduct % promotion.Quantity * product.Price);
            else
                return noofProduct * product.Price;
            

         
        }

        private decimal MultiProductPrice(List<Product> products, List<ProductOrder> productsorders, decimal discoutPrice)
        {

            decimal cost;

               var minQuanity = productsorders.Min(po => po.Quantity);
                cost = productsorders.Min(po => po.Quantity) * discoutPrice;

                productsorders.All(po =>
                {
                    cost += (po.Quantity - productsorders.Min(Subpo => Subpo.Quantity)) * (products.Find(p => p.Id == po.Id).Price);
                    return true;
                });


                return cost;
                        
        }
    }
}
