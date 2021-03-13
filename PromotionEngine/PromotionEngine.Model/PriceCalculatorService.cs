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

        /// <summary>
        /// Get Total price based on promotion rule
        /// </summary>
        /// <param name="products"></param>
        /// <param name="promotions"></param>
        /// <param name="productsorders"></param>
        /// <returns></returns>
        public decimal GetTotalPrice(List<Product> products, List<Promotion> promotions, List<ProductOrder> productsorders)
        {
            decimal totalCost = 0;

            try
            { 
                ///Multi Product Promotion
            promotions.All(pm =>
            {

                if (pm.ProductIDs != null && productsorders.FindAll(po => pm.ProductIDs.Any(b => po.Id == b)).Count>1)
                {
                    totalCost += MultiProductPrice(products, productsorders.FindAll(po => pm.ProductIDs.Any(b => po.Id == b)), pm.DiscountPrice);

                    productsorders.RemoveAll(po => pm.ProductIDs.Any(b => po.Id == b));

                }

                return true;
            });


                ///Single Product Promotion
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
                Message = "Total cost calculatation done succesfully.";
                

            return totalCost;
          }
            catch (Exception ex)
            {
                Status = false;
                Message ="Failed:- "+ ex.Message;
                return 0;
            }

        }

        /// <summary>
        /// Handle Single Product Promotion
        /// </summary>
        /// <param name="product"></param>
        /// <param name="noofProduct"></param>
        /// <param name="promotion"></param>
        /// <returns></returns>
        private decimal SingleProductPrice(Product product, int noofProduct, Promotion promotion)
        {

          
            if (promotion != null)
                return (noofProduct / promotion.Quantity) * promotion.DiscountPrice + (noofProduct % promotion.Quantity * product.Price);
            else
                return noofProduct * product.Price;
            

         
        }
        /// <summary>
        /// Handle Multiple Product Promotion
        /// </summary>
        /// <param name="products"></param>
        /// <param name="productsorders"></param>
        /// <param name="discoutPrice"></param>
        /// <returns></returns>
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
