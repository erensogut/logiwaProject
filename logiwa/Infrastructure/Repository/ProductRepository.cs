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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        DataContext _ctx;
        public ProductRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Product>> GetByDescription(string description, string correlationToken)
        {
            return Get().Where(x => x.Description == description).ToList();

        }

        public async Task<List<Product>> GetByTitle(string title, string correlationToken)
        {
            return Get().Where(x => x.Title == title).ToList();
        }

        public async Task<bool> IsStockInRange(string correlationToken, int productId, int min, int max)
        {
            int stock = _ctx.Products.Where(x => x.Id == productId).FirstOrDefault().StockQuantity;
            return (stock < max && stock > min);
        }

        public async Task<List<Product>> SearchByCategory(string searchText, string correlationToken)
        {
            var query = from p in _ctx.Products
                        where p.Category.CategoryName.Contains(searchText)
                        select p;
            return query.Include("Category").ToList();
        }

        public async Task<List<Product>> SearchByDescription(string searchText, string correlationToken)
        {
            var query = from p in _ctx.Products
                        where p.Description.Contains(searchText)
                        select p;
            return query.Include("Category").ToList();
        }

        public async Task<List<Product>> SearchByTitle(string searchText, string correlationToken)
        {
            var query = from p in _ctx.Products
                        where p.Title.Contains(searchText)
                        select p;
            return query.Include("Category").ToList();
        }
    }
}
