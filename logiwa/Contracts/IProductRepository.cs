using logiwa.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Contracts
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<List<Product>> GetByTitle(String title, string correlationToken);

        Task<List<Product>> GetByDescription(String description, string correlationToken);


        Task<List<Product>> SearchByTitle(String searchText, string correlationToken);

        Task<List<Product>> SearchByDescription(String searchText, string correlationToken);

        Task<List<Product>> SearchByCategory(String searchText, string correlationToken);
        Task<bool> IsStockInRange(string correlationToken, int productId,int min, int max);
    }
}
