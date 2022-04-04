using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        public Guid ID_order { get; private set; }
        public Guid ID_user { get; private set; }
        public Guid ID_product { get; private set; }
        public string Description { get; private set; }

        public Order(Guid iD_order, Guid iD_user, Guid iD_product, string description)
        {
            ID_order = iD_order;
            ID_user = iD_user;
            ID_product = iD_product;
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

    }

    
}
