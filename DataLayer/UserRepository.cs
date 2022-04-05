using Entity;
using System.Data;

namespace DataLayer
{
    public class UserRepository : SQLDataHelper
    {
        public UserRepository(string nameTable, string connectionPath) : base(nameTable, connectionPath) {} // Создание объекта и вызов конструктора родителя (из DR)

        public void CreateUser(User user)
        {
             CustomSql(@$"INSERT INTO [dbo].[UsersList]
                ([FirstName]
                    ,[LastName]
                    ,[MiddleName]
                    ,[Age]
                    ,[Login]
                    ,[Password]
                    ,[Email]
                    ,[Phone]
                    ,[IsAdmin])
                VALUES
                    ('{user.FirstName}'
                    ,'{user.LastName}'
                    ,'{user.MiddleName}'
                    ,'{user.Age}'
                    ,'{user.Login}'
                    ,'{user.Password}'
                    ,'{user.Email}'
                    ,'{user.Phone}'
                    ,'{user.IsAdmin}')");
        }
        public User ReadUser(Guid id)
        {
            DataTable dataTable = CustomSql($"select * from {NameTable} WHERE ID = '{id}'");
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new User(row.Field<Guid>("ID"), row.Field<string>("FirstName"), row.Field<string>("LastName"), row.Field<string>("MiddleName"), row.Field<int>("Age"), row.Field<string>("Login"), row.Field<string>("Password"), row.Field<string>("Email"), row.Field<string>("Phone"), row.Field<bool>("IsAdmin"));
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
                return new User(row.Field<Guid>("ID"), row.Field<string>("FirstName"), row.Field<string>("LastName"), row.Field<string>("MiddleName"), row.Field<int>("Age"), row.Field<string>("Login"), row.Field<string>("Password"), row.Field<string>("Email"), row.Field<string>("Phone"), row.Field<bool>("IsAdmin"));
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
                users.Add(new User(row.Field<Guid>("ID"), row.Field<string>("FirstName"), row.Field<string>("LastName"), row.Field<string>("MiddleName"), row.Field<int>("Age"), row.Field<string>("Login"), row.Field<string>("Password"), row.Field<string>("Email"), row.Field<string>("Phone"), row.Field<bool>("IsAdmin"))); 
            }
            return users;

        }
        public void UpdateUser(User user)
        {
           CustomSql(@$"UPDATE [dbo].[UsersList]
                SET [FirstName] = '{user.FirstName}'
                    ,[LastName] = '{user.LastName}'
                    ,[MiddleName] = '{user.MiddleName}'
                    ,[Age] = '{user.Age}'
                    ,[Login] = '{user.Login}'
                    ,[Password] = '{user.Password}'
                    ,[Email] = '{user.Email}'
                    ,[Phone] = '{user.Phone}'
                    ,[IsAdmin] = '{user.IsAdmin}'              
                WHERE ID = '{user.Id}'");
        }
        public void DeleteUser(User user)
        {
          CustomSql(@$"DELETE FROM [dbo].[UsersList]
               WHERE ID = '{user.Id}'");
        }

        

    }
}