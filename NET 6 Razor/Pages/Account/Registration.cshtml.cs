using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using System.Text.RegularExpressions;

namespace NET_6_Razor.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private UserManager userManager = DependencyResolver.Instance.UserManager;

        public void OnGet()
        {

        }
        public IActionResult OnGetSignin()
        {
            return Page();
        }

        public string allError = "";
        public string addError = "Некорректный ";
        bool errorFlag = false;
        Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexLogin = new Regex(@"^(?=.*[a-zA-Z]{1,})(?=.*[\d]{0,})[a-zA-Z0-9]{1,15}$");
        public IActionResult OnPost(Guid id, string login, string password, string secondPassword, string name, string email, int age)
        {
            if (!regexEmail.Match(email).Success)
            {
                errorFlag = true;
                addError += "email ";
            }
            if (!regexLogin.Match(login).Success)
            {
                errorFlag = true;
                addError += "login ";
            }
            if (age < 18 && age > 65)
            {
                errorFlag = true;
                addError += "возраст ";
            }
            if (password != secondPassword)
            {
                errorFlag = true;
                addError += "пароль ";
            }
            if (errorFlag)
            {
                allError = addError;
            }
            if (userManager.checkCorrectInputs(password, name, email, age) && errorFlag == false)
                {
                    userManager.addNewUser(id, login, password, name, email, age);
                    return RedirectToPage("/Account/Login");
            }
            errorFlag = false;
            return Page();
        }
    }
}

