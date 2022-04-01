using Entity;
using System.Data;

namespace DataLayer
{
    public class UserRepository : SQLDataHelper
    {
        public UserRepository(string nameTable, string connectionPath) : base(nameTable, connectionPath) {} // Создание объекта и вызов конструктора родителя (из DR)

        public void AddUser(User user)
        {
             CustomSql(@$"INSERT INTO [dbo].[UsersList]
                   ([ID]
                   ,[Login]
                   ,[Password]
                   ,[Name]
                   ,[Email]
                   ,[Age]
             VALUES
                   ({user.Login}
                   ,{user.Password}
                   ,{user.Name}
                   ,{user.Email}
                   ,{user.Age}");
        }
        public User ReadUser(Guid id)
        {
            DataTable dataTable = CustomSql($"select * from {NameTable} WHERE ID = '{id}'");
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new User(row.Field<Guid>("ID"), row.Field<string>("Login"), row.Field<string>("Password"), row.Field<string>("Name"), row.Field<string>("Email"), row.Field<int>("Age"));
            }
            else
            {
                return null;
            }           
        }
        public User FindUser(string login)
        {
            DataTable dataTable = CustomSql($"select * from {NameTable} WHERE Login = '{login}'");
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new User(row.Field<Guid>("ID"), row.Field<string>("Login"), row.Field<string>("Password"), row.Field<string>("Name"), row.Field<string>("Email"), row.Field<int>("Age"));
            }
            else
            {
                return null;
            }
        }
        public List<User> ReadAllUsers()
        {
            DataTable dataTable = CustomSql($"select * from {NameTable}");
            List<User> users = new();
            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(new User(row.Field<Guid>("ID"), row.Field<string>("Login"), row.Field<string>("Password"), row.Field<string>("Name"), row.Field<string>("Email"), row.Field<int>("Age"))); 
            }
            return users;

        }
        public void UpdateUser(User user)
        {
           CustomSql(@$"UPDATE [dbo].[UsersList]
               SET [ID] = '{user.Id}'
                  ,[Login] = '{user.Login}'
                  ,[Password] = '{user.Password}'
                  ,[Name] = '{user.Name}'
                  ,[Email] = '{user.Email}'
                  ,[Age] = '{user.Age}'
               WHERE ID = '{user.Id}'>");
        }
        public void DeleteUser(User user)
        {
          CustomSql(@$"DELETE FROM [dbo].[UsersList]
               WHERE ID = '{user.Id}'");
        }

    }
}