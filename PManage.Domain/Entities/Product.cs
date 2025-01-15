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
            if (string.IsNullOrEmpty(Name))
                throw new Exception("O nome do produto é obrigatório.");

            if (Price <= 0)
                throw new Exception("O preço do produto deve ser maior que zero.");

            if (StockQuantity < 0)
                throw new Exception("A quantidade em estoque não pode ser negativa.");
        }
    }
}
