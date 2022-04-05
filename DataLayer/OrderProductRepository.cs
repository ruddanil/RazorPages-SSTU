using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderProductRepository : SQLDataHelper
    {
        public OrderProductRepository(string nameTable, string connectionPath) : base(nameTable, connectionPath) { }

        public void CreateOrderProduct(OrderProduct orderProduct)
        {
            CustomSql(@$"INSERT INTO [dbo].[OrderProduct]
                   ([ID_order]
                   ,[ID_product]
                   ,[Quantity]
                   ,[PricePerUnit])
             VALUES
                   ('{orderProduct.ID_order}'
                   ,'{orderProduct.ID_product}'
                   ,'{orderProduct.Quantity}'
                   ,'{orderProduct.PricePerUnit}')");
        }

        public OrderProduct ReadOrderProduct(Guid id_orderProduct)
        {
            DataTable dataTable = CustomSql($"select * from {NameTable} WHERE ID_orderProduct = '{id_orderProduct}'");
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new OrderProduct(row.Field<Guid>("ID_orderProduct"), row.Field<Guid>("ID_order"), row.Field<Guid>("ID_product"), row.Field<int>("Quantity"), row.Field<decimal>("PricePerUnit"));
            }
            else
            {
                return null;
            }
        }

        public List<OrderProduct> ReadAllOrderProducts()
        {
            DataTable dataTable = CustomSql($"select * from {NameTable}");
            List<OrderProduct> orderProducts = new();
            foreach (DataRow row in dataTable.Rows)
            {
                orderProducts.Add(new OrderProduct(row.Field<Guid>("ID_orderProduct"), row.Field<Guid>("ID_order"), row.Field<Guid>("ID_product"), row.Field<int>("Quantity"), row.Field<decimal>("PricePerUnit")));
            }
            return orderProducts;
        }

        public void UpdateOrderProduct(OrderProduct orderProduct)
        {
            CustomSql(@$"UPDATE [dbo].[OrderProduct]
               SET [ID_order] = '{orderProduct.ID_order}'
                ,[ID_product] = '{orderProduct.ID_product}'
                ,[Quantity] = '{orderProduct.Quantity}'
                ,[PricePerUnit] = '{orderProduct.PricePerUnit}'");
        }
        public void DeleteOrderProduct(OrderProduct orderProduct)
        {
            CustomSql(@$"DELETE FROM [dbo].[Order]
               WHERE ID_orderProduct = '{orderProduct.ID_orderProduct}'");
        }
    }
}
