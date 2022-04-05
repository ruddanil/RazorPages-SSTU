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
        readonly Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        readonly Regex regexLogin = new Regex(@"^(?=.*[a-zA-Z]{1,})(?=.*[\d]{0,})[a-zA-Z0-9]{1,15}$");
        readonly Regex regexPhone = new Regex(@"^([+]?\d{1,2}[-\s]?|)\d{3}[-\s]?\d{3}[-\s]?\d{4}$");
        public IActionResult OnPostCreate(Guid id, string firstName, string lastName, string middleName, int age, string login, string password, string secondPassword, string email, string phone, bool isAdmin)
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
            if (!regexPhone.Match(phone).Success)
            {
                errorFlag = true;
                addError += "телефон ";
            }
            if (errorFlag)
            {
                allError = addError;
            }
            if (userManager.checkCorrectInputs(password, email, age) && errorFlag == false)
            {
                    userManager.createUser(id, firstName, lastName, middleName, age, login, password, email, phone, isAdmin);
                    return RedirectToPage("/Account/Login");
            }
            errorFlag = false;
            return Page();
        }
    }
}

