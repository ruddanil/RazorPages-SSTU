namespace Entity
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }


        public User(Guid id, string login, string password)
        {
            Id = id;

            if (login != null)
            {
                Login = login;
            }
            else
            {
                throw new ArgumentNullException(nameof(login));
            }
            if (password != null)
            {
                Password = password;
            }
            else
            {
                throw new ArgumentNullException(nameof(password));
            }

        }

        public User(Guid id, string login, string password, string name, string email, int age) : this(id, login, password) 
        {
            Name = name;
            Email = email;
            Age = age;
        }

    }
}