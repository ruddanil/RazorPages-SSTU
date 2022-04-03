using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages
{
    public class RadiobuttonModel : PageModel
    {
        public void OnGet()
        {
        }
        public string result;
        public void OnPost(string textBox, List<string> listBox, string dropdownList, string radio)
        {
            result = textBox + " | " + string.Join("; ", listBox) + " | " + dropdownList + " | " + radio;
        }
    }
}
