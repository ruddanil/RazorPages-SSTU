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
        public DateTime Date { get; private set; }

        public Order(Guid id_order, Guid id_user, DateTime date)
        {
            ID_order = id_order;
            ID_user = id_user;
            Date = date;
        }
    }
}
