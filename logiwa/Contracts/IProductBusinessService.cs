using logiwa.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Contracts
{
    public interface IProductBusinessService
    {
        Task<List<Product>> Search(string correlationToken, string searchText);

        Task<bool> StockQuantityRange(string correlationToken,int productId, int min, int max);

    }
}
