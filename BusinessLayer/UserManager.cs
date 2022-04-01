using DataLayer;

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
    }
}