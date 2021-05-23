using logiwa.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Infrastructure.DataStore
{
    public class DataInitializer
    {
        public static async Task InitializeDatabaseAsync(IServiceScope serviceScope)
        {
            var context = serviceScope.ServiceProvider.GetService<DataContext>();

            if (context != null)
            {
                var databaseCreated = context.Database.EnsureCreated();

                // Determine if database has been seeded
                if (!context.Products.Any())
                {
                    await Seed(context);
                }
            }
        }
        private static async Task Seed(DataContext context)
        {
            var categories = new List<Category>
            {
                new Category {CategoryName = "Best Seller",MinStockQuantity=10},
                new Category {CategoryName = "Novel",MinStockQuantity=10},
                new Category {CategoryName = "New Releases",MinStockQuantity=10},
                new Category {CategoryName = "Comedy",MinStockQuantity=10},
                new Category {CategoryName = "Children's Book",MinStockQuantity=10},


            };
            try
            {
                new List<Product>{
                    // Country
                    
                    new Product("1984 - George Orwell","Written more than 70 years ago, 1984 was George Orwell’s chilling prophecy about the future.",categories.Single(a=>a.CategoryName=="Best Seller"),9,false),
                    new Product("The Girl on the Train","The #1 New York Times Bestseller, USA Today Book of the Year, now a major motion picture starring Emily Blunt.",categories.Single(a=>a.CategoryName=="Novel"),20,true),
                    new Product("Is This Anything?","The first book in 25 years from Jerry Seinfeld features his best work across five decades in comedy.",categories.Single(a=>a.CategoryName=="Comedy"),30,true),
                    new Product("Sooley","John Grisham takes you to a different kind of court in his first basketball novel. Samuel “Sooley” Sooleymon is a raw, young talent with big hoop dreams—and even bigger challenges off the court",categories.Single(a=>a.CategoryName=="New Releases"),40,true)

                }.ForEach(a => context.Products.Add(a)); ;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Todo: Add Logging
                    string errorMessage = $"Error seeding Product Catalog data {ex.Message}";
                    throw;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error seeding Product Catalog data {ex.Message}";
                throw;
            }
        }

    }
}
