using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Account
{
    public class LoginModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager; // Обращение к экземпляру UserManager
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
        public IActionResult OnPost(string login, string password)
        {
            if (userManager.checkPassword(login, password))
            {
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
