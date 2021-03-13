using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.AppServices.Messages
{
  public  class ProductResponseBase : ResponseBase
    {
   

        public decimal TotalCost
        { get; set; }
       
    }
}
