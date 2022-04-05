using DataLayer;
using Entity;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class UserManager 
    {
        private UserRepository userRepository; 

        public UserManager(UserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public bool checkPassword(string login, string password)
        {
            var user = userRepository.FindUser(login);
            if (user == null)
            {
                return false;
            }
            else
            {
                return password == user.Password;
            }
        }
        Dictionary<string, string> logPass = new Dictionary<string, string>() { { "log", "12345"}, { "lOg1", "12345qWerty" } };
        public bool checkPasswordSimple(string login, string password)
        {
            if (!logPass.ContainsKey(login.ToLower())) return false; 
            var truePassword = logPass[login.ToLower()];
            if (truePassword == null)
            {
                return false;
            }
            else
            {
                return password == truePassword;
            }
        }
        public bool checkCorrectInputs(string password, string email, int age)
        {
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return (password != null && email != null && (age >= 18 && age <= 65) && regexEmail.Match(email).Success);
        }
        public void createUser(Guid id, string firstName, string lastName, string middleName, int age, string login, string password, string email, string phone, bool isAdmin)
        {
            User user = new User(id, firstName, lastName, middleName, age, login, password, email, phone, isAdmin);
            userRepository.CreateUser(user);
        }
        public User readUser(Guid id)
        {
            return userRepository.ReadUser(id);
        }
        public void updateUser(User user)
        {
            userRepository.UpdateUser(user);
        }
        public void deleteUser(Guid id)
        {
            User user = userRepository.ReadUser(id);
            userRepository.DeleteUser(user);
        }
        public List<User> readAllUsers()
        {
            return userRepository.ReadAllUsers();
        }
        public User findUser(string login)
        {
            return userRepository.FindUser(login);
        }
    }
}