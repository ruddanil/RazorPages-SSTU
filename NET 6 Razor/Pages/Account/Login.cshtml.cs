using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Account
{
    public class LoginModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager; // Обращение к экземпляру UserManager
        public User user;
        bool isAdmin;
        Guid id;
        public string errorMassage;
        public void OnGet()
        {

        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("login");
            HttpContext.Session.Remove("password");
            return Page();
        }
        public IActionResult OnPostLogin(string login, string password)
        {
            if (userManager.checkPassword(login, password))
            {
                user = userManager.findUser(login);
                isAdmin = user.IsAdmin;
                id = user.Id;
                HttpContext.Session.SetString("id", id.ToString());
                HttpContext.Session.SetString("isAdmin", isAdmin.ToString());
                HttpContext.Session.SetString("login", login);
                HttpContext.Session.SetString("password", password);
                return RedirectToPage("Welcome");
            }
            else
            {
                errorMassage = "Неверный логин или пароль";
                return Page();
            }
        }
    }
}
