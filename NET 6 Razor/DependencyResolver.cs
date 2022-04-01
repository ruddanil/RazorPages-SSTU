using BusinessLayer;
using DataLayer;

namespace NET_6_Razor
{
    public class DependencyResolver
    {
        #region singleton 
        private static DependencyResolver _instance;

        public static DependencyResolver Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }
        #endregion

        private string connectionString = @"Data Source=ASUS-ROG-G14\SSTU2021;Initial Catalog=Infotech;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public UserManager UserManager { get; private set; }
        private DependencyResolver() 
        {
            UserRepository userRepository = new("UsersList", connectionString);
            UserManager = new(userRepository);
        }
    }
}

