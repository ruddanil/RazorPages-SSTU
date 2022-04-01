using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages
{
    public class WelcomeModel : PageModel
    {
        public string name;
        public void OnGet(string name)
        {
            this.name= name;
        }
    }
}
