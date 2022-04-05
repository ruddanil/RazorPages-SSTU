using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.UserCRUD
{
    public class UserUpdateModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager;
        public User user;
        public User updatedUser;
        public IActionResult OnGet(Guid id)
        {
            user = userManager.readUser(id);
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
            user = userManager.readUser(id);
            return Page();
        }
        public IActionResult OnPostUpdate(Guid id, string firstName, string lastName, string middleName, int age, string login, string password, string email, string phone, bool isAdmin)
        {
            user = userManager.readUser(id);
            User updatedUser = new(id, firstName, lastName, middleName, age, login, password, email, phone, isAdmin);
            userManager.updateUser(updatedUser);
            return RedirectToPage("/UserCRUD/UserList");
        }
    }
}
