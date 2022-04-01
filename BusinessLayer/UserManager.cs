using DataLayer;
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
        Dictionary<string, string> logPass = new Dictionary<string, string>() { { "log", "12345"}, { "log1", "12345qwerty" } };
        public bool checkPasswordSimple(string login, string password)
        {
            if (!logPass.ContainsKey(login)) return false; 
            var truePassword = logPass[login];
            if (truePassword == null)
            {
                return false;
            }
            else
            {
                return password == truePassword;
            }
        }
        public bool checkCorrectInputs(string password, string name, string email, int age)
        {
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return (password == null || name == null || email == null || age == null || (age < 18 && age > 65) || !regexEmail.Match(email).Success);
        }
    }
}