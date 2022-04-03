using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Account
{
    public class WelcomeModel : PageModel
    {
        public string login;
        public string password;
        public void OnGet()
        {
            login = HttpContext.Session.GetString("login");
            password = HttpContext.Session.GetString("password");
        }

    }
}