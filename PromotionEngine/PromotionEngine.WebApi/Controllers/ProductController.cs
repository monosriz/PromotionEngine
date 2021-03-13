using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PromotionEngine.AppServices;
using PromotionEngine.AppServices.Messages;
using PromotionEngine.Model;
using PromotionEngine.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List< Product> _products;
        List<Promotion> _promotions;
        ApplicationPriceCalculatorService _applicationPriceCalculatorService;
        
        public ProductController(List<Product> products, List<Promotion> promotions, ApplicationPriceCalculatorService applicationPriceCalculatorService)
        {
            _applicationPriceCalculatorService = applicationPriceCalculatorService;
            _products = products;
            _promotions = promotions;
        }

        /// <summary>
        /// Get  Product Cost
        /// </summary>
        /// <param name="productorder"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("TotalCost")]
        public IActionResult TotalCost([FromBody] List<ProductOrder> productorder)

        {

            ProductResponseBase _response = _applicationPriceCalculatorService.CalculatePrice(_products,_promotions, productorder );
            return Ok(_response);
            

        }
    }
}
