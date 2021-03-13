using PromotionEngine.AppServices.Messages;
using PromotionEngine.Model;
using PromotionEngine.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.AppServices
{
    public class ApplicationPriceCalculatorService
    {
        private PriceCalculatorService _priceCalculatorService;

        public ApplicationPriceCalculatorService(PriceCalculatorService PriceCalculatorService)
        {
            _priceCalculatorService = PriceCalculatorService;
        }
        public ProductResponseBase CalculatePrice(List<Product> Products, List<Promotion> Promotions, List<ProductOrder> Productsorders)
        {
            bool _status = true;
            var _reponse = new ProductResponseBase();
            decimal _totalCost ;
            try
            {
                if (Products.Count ==0 )
                {
                    _reponse.Success = false;
                    _reponse.Message = "Product master  can't be empty.";
                    return _reponse;

                }

                if (Productsorders.Count == 0)
                {
                    _reponse.Success = false;
                    _reponse.Message = "Product cart can't be empty.";
                    return _reponse;
                }

               

                _totalCost = _priceCalculatorService.GetTotalPrice(Products,  Promotions, Productsorders);

                _reponse.Success = true;
                _reponse.Message = "Prduct calculate Succesfully.";
                _reponse.TotalCost = _totalCost;

            }

            catch (Exception ex)
            {
                _reponse.Success = false;
                _reponse.Message = "Failed -  " + ex.Message;
            }


            return _reponse;

        }
    }
}
