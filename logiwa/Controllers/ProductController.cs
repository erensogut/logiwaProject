using logiwa.Contracts;
using logiwa.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace logiwa.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBusinessService _productBusinessServices;

        public ProductController(IProductBusinessService productBusinessServices)
        {
            _productBusinessServices = productBusinessServices;
        }
      

        [ProducesResponseType(typeof(List<Product>), 200)]
        [HttpGet("Product/Search/{correlationToken}", Name = "SearchProduct")]
        public async Task<IActionResult> Search(string correlationToken, string searchText)
        {
            Guard.ArgumentNotNullOrEmpty(correlationToken, "correlationToken");

            var products = await _productBusinessServices.Search(correlationToken, searchText);

            return new ObjectResult(products);

        }

        [ProducesResponseType(typeof(List<Product>), 200)]
        [HttpGet("Product/Stock/{correlationToken}", Name = "StockRange")]
        public async Task<IActionResult> Stock(string correlationToken,int productId, int min, int max )
        {
            Guard.ArgumentNotNullOrEmpty(correlationToken, "correlationToken");

            var result= await _productBusinessServices.StockQuantityRange(correlationToken, productId, min, max);

            return new ObjectResult(result);

        }
    }
}
