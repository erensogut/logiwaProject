using logiwa.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Contracts
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<List<Category>> GetAll(string correlationToken);

        Task<Category> GetByCategoryName(String name, string correlationToken);

    }
}
