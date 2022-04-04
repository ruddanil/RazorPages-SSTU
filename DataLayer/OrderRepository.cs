using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderRepository : SQLDataHelper
    {
        public OrderRepository(string nameTable, string connectionPath) : base(nameTable, connectionPath) { }


    }
}
