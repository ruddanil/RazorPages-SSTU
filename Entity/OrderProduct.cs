using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderProduct
    {
        public Guid ID_orderProduct { get; private set; }
        public Guid ID_order { get; private set; }
        public Guid ID_product { get; private set; }
        public int Quantity { get; private set; }
        public decimal PricePerUnit { get; private set; }

        public OrderProduct(Guid id_orderProduct, Guid id_order, Guid id_product, int quantity, decimal pricePerUnit)
        {
            ID_orderProduct = id_orderProduct;
            ID_order = id_order;
            ID_product = id_product;
            Quantity = quantity;
            PricePerUnit = pricePerUnit;
        }
    }
}
