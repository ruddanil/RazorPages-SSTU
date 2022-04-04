using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public Guid ID_product { get; private set; }
        public string Title { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }

        public Product(Guid iD_product, string title, int quantity, decimal price, string description)
        {
            ID_product = iD_product;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Quantity = quantity;
            Price = price;
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
