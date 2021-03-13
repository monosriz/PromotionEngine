using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PromotionEngine.Model.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromotionEngine.XUnitTest
{
   public class TestPromotionController : IClassFixture<WebApplicationFactory<WebApi.Startup>>
    {
        public HttpClient Client { get; }

        public TestPromotionController(WebApplicationFactory<WebApi.Startup> fixture)
        {
            Client = fixture.CreateClient();
            
        }

        [Fact]
        public async Task Test_SingleQuanity_SigleProductPromotion()
        {


            List<ProductOrder> productOrders = new List<ProductOrder>();


            productOrders.Add(new ProductOrder() { Id = "A", Quantity = 1 });
            productOrders.Add(new ProductOrder() { Id = "B", Quantity = 1 });
            productOrders.Add(new ProductOrder() { Id = "C", Quantity = 1 });

            var content = new StringContent(JsonConvert.SerializeObject(productOrders), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/promotion/totalcost", content);


            dynamic ResponseMessage = JObject.Parse(await response.Content.ReadAsStringAsync());


            Assert.Equal(100, (int)ResponseMessage.totalCost);


        }

        [Fact]
        public async Task Test_MultiQuanity_SigleProductPromotion()
        {


            List<ProductOrder> productOrders = new List<ProductOrder>();


            productOrders.Add(new ProductOrder() { Id = "A", Quantity = 5 });
            productOrders.Add(new ProductOrder() { Id = "B", Quantity = 5 });
            productOrders.Add(new ProductOrder() { Id = "C", Quantity = 1 });

            var content = new StringContent(JsonConvert.SerializeObject(productOrders), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/promotion/totalcost", content);


            dynamic ResponseMessage = JObject.Parse(await response.Content.ReadAsStringAsync());


            Assert.Equal(370, (int)ResponseMessage.totalCost);


        }

        [Fact]
        public async Task Test_MultiQuanity_MultuProductPromotion()
        {


            List<ProductOrder> productOrders = new List<ProductOrder>();


            productOrders.Add(new ProductOrder() { Id = "A", Quantity = 3 });
            productOrders.Add(new ProductOrder() { Id = "B", Quantity = 5 });
            productOrders.Add(new ProductOrder() { Id = "C", Quantity = 1 });
            productOrders.Add(new ProductOrder() { Id = "D", Quantity = 1 });
            var content = new StringContent(JsonConvert.SerializeObject(productOrders), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/promotion/totalcost", content);


            dynamic ResponseMessage = JObject.Parse(await response.Content.ReadAsStringAsync());


            Assert.Equal(280, (int)ResponseMessage.totalCost);


        }

        [Fact]
        public async Task Test_InvalidProductOrder()
        {


            List<object> productOrders = new List<object>();


            productOrders.Add(new  { Id = "A", Quantity = 3 });
            productOrders.Add(new  { Id = "B", Quantity = 5 });
            productOrders.Add(new  { ID = "C", Quantity = "CCC" });
          
            var content = new StringContent(JsonConvert.SerializeObject(productOrders), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/promotion/totalcost", content);


            dynamic ResponseMessage = JObject.Parse(await response.Content.ReadAsStringAsync());


            Assert.Equal(response.StatusCode.ToString(), HttpStatusCode.BadRequest.ToString());


        }
    }
}
