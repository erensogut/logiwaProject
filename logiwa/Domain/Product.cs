using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Domain
{
    public class Product:Entity
    {
        public String Title { get; private set; }
        public String Description { get; private set; }
        public Category Category { get; private set; }
        public int StockQuantity { get; private set; }
        public bool IsLive { get; private set; }

        public Product()
        {

        }
        public Product(String title, String description, Category category, int stockQuantity,bool isLive)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (title.Length > 200)
            {
                throw new ArgumentOutOfRangeException(nameof(title));
            }
            if (isLive&&category==null)
            {
                throw new InvalidOperationException(nameof(isLive));
            }
            if (isLive && stockQuantity < category.MinStockQuantity)
            {
                throw new ArgumentOutOfRangeException(nameof(stockQuantity));
            }
            Title = title;
            Description = description;
            Category = category;
            StockQuantity = stockQuantity;
            IsLive = isLive;

        }
    }
}
