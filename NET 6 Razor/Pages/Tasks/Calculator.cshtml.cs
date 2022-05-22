using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Tasks
{
    public class CalculatorModel : PageModel
    {
        public void OnGet()
        {
        }
        public string result;

        public void OnPost(string number1, string number2, string option)
        {
            decimal num1, num2;
            try
            {
                num1 = decimal.Parse(number1.Replace(".", ","));
                num2 = decimal.Parse(number2.Replace(".", ","));
                switch (option)
                {
                    case "+": result = (num1 + num2).ToString(); break;
                    case "-": result = (num1 - num2).ToString(); break;
                    case "*": result = (num1 * num2).ToString(); break;
                    case "/": if (num1 != 0) result = (num1 / num2).ToString(); else result = "0"; break;
                }
            }
            catch (Exception ex)
            {
                result = "¬ведено некорректное значение {ex}";
            }

        }
    }
}
