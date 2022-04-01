using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages
{
    public class SimpleLoginModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager; // Обращение к экземпляру UserManager
        public string errorMassage;
        public IActionResult OnPost(string login, string password)
        {
            if (userManager.checkPasswordSimple(login, password))
            {
                return Redirect($"Authorization/Welcome?name={login}");
            }
            else
            {
                errorMassage = "Неверный логин или пароль";
                return Page();
            }
        }
    }
}
