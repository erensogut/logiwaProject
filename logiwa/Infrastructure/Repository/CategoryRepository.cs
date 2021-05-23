using logiwa.Contracts;
using logiwa.Domain;
using logiwa.Infrastructure.DataStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext ctx) : base(ctx)
        {
        }
        public async Task<List<Category>> GetAll(string correlationToken)
        {
            return Get().ToList();
        }

        public async Task<Category> GetByCategoryName(string name, string correlationToken)
        {
            return Get().Where(x => x.CategoryName==name).FirstOrDefault();

        }
    }
}
