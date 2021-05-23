using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Domain
{
    public class Category:Entity
    {
        public String CategoryName { get; set; }
        public int MinStockQuantity { get; set; }
    }
}
