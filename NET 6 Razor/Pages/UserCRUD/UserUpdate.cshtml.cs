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
        public IActionResult OnPostUpdate(Guid id, string name, int age)
        {
            user = userManager.readUser(id);
            userManager.updateUser(id, user.Login, user.Password, name, user.Email, age);
            return RedirectToPage("/UserCRUD/UserList");
        }
    }
}
