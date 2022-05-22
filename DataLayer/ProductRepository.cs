using Entity;
using System.Data;

namespace DataLayer
{
    public class ProductRepository : SQLDataHelper
    {
        public ProductRepository(string nameTable, string connectionPath) : base(nameTable, connectionPath) { }

        public void CreateProduct(Product product)
        {
            CustomSql(@$"INSERT INTO [dbo].[Product]
                   ([Title]
                   ,[Quantity]
                   ,[Price]
                   ,[Description])
             VALUES
                   ('{product.Title}'
                   ,'{product.Quantity}'
                   ,'{product.Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}'
                   ,'{product.Description}')");
        }
        public Product ReadProduct(Guid id_product)
        {
            DataTable dataTable = CustomSql($"select * from {NameTable} WHERE ID_product = '{id_product}'");
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new Product(row.Field<Guid>("ID_product"), row.Field<string>("Title"), row.Field<int>("Quantity"), row.Field<decimal>("Price"), row.Field<string>("Description"));
            }
            else
            {
                return null;
            }
        }
        public List<Product> ReadAllProducts()
        {
            DataTable dataTable = CustomSql($"select * from {NameTable}");
            List<Product> products = new();
            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(new Product(row.Field<Guid>("ID_product"), row.Field<string>("Title"), row.Field<int>("Quantity"), row.Field<decimal>("Price"), row.Field<string>("Description")));
            }
            return products;
        }

        public void UpdateProduct(Product product)
        {
            CustomSql(@$"UPDATE [dbo].[Product]
               SET [Title] = '{product.Title}'
                  ,[Quantity] = '{product.Quantity}'
                  ,[Price] = '{product.Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}'
                  ,[Description] = '{product.Description}'
               WHERE ID_product = '{product.ID_product}'");
        }
        public void DeleteProduct(Product product)
        {
            CustomSql(@$"DELETE FROM [dbo].[Product]
               WHERE ID_product = '{product.ID_product}'");
        }

    }
}
