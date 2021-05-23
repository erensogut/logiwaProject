using logiwa.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Domain
{
    public class ProductBusinessService : IProductBusinessService
    {
        private readonly IProductRepository _productRepository;
        public ProductBusinessService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Search(string correlationToken, string searchText)
        {
            var productsFromTitle = await _productRepository.SearchByTitle( searchText, correlationToken);
            var productsFromDescription = await _productRepository.SearchByDescription( searchText, correlationToken);
            var productsFromCategory = await _productRepository.SearchByDescription( searchText, correlationToken);
            return  productsFromTitle.Union(productsFromDescription).Union(productsFromCategory).ToList();
        }

        public async Task<bool> StockQuantityRange(string correlationToken,int productId, int min, int max)
        {
            return await _productRepository.IsStockInRange(correlationToken, productId, min, max);
        }
    }
}
