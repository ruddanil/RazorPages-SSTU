using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SQLDataHelper
    {
        protected string DataBaseConnectionPath { get; set; }

        public SQLDataHelper(string nameTable, string connectionPath )
        {
            NameTable = nameTable;
            Table = new DataTable();
        }

        public string NameTable { get; private set; }
        protected DataTable Table { get; set; }

        public new DataTable CustomSql(string request)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataBaseConnectionPath))
            using (SqlCommand cmd = new SqlCommand(request, connection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(request, connection);
                adapter.Fill(table);
                cmd.ExecuteNonQuery();
            }
            return table;
        }

    }
}
