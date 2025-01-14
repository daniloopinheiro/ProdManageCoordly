using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PManage.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name)) throw new Exception("Product name is required.");
            if (Price <= 0) throw new Exception("Product price must be greater than zero.");
            if (StockQuantity < 0) throw new Exception("Stock quantity cannot be negative.");
        }
    }
}
