using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Contracts
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Remove(T entity);
        Task Update(T entity);
        Task<int> SaveChanges();
    }
}
