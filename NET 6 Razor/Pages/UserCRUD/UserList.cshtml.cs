using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.UserCRUD
{
    public class UserListModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager;
        public List<User> userList;
        public void OnGet()
        {
            userList = userManager.readAllUsers();
        }
        public void OnPostDelete(Guid id)
        {
            userList = userManager.readAllUsers();
            User user = userManager.readUser(id);
            if (user != null)
            {
                userManager.deleteUser(id);
            }
            userList = userManager.readAllUsers();
        }
    }
}
