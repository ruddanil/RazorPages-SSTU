using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class SQLDataHelper
    {
        protected string ConnectionString { get; set; } // Строка подключения, доступна у наследников

        public SQLDataHelper(string nameTable, string connectionString) // Конструктор (принимает название таблицы в БД и строку подключения)
        {
            ConnectionString = connectionString;
            NameTable = nameTable;
            Table = new DataTable();
        }

        public string NameTable { get; private set; }
        protected DataTable Table { get; set; }

        public DataTable CustomSql(string request)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString)) // Using - автоматическое закрытие
            using (SqlCommand cmd = new SqlCommand(request, connection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(request, connection); // Мост сопоставления таблицы на сервере и у нас
                adapter.Fill(table); // Добавляет строки 
                cmd.ExecuteNonQuery(); // Выполнение команды (возвращает количество измененных строк) 
            }
            return table;
        }

    }
}
