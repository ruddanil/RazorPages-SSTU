using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class OrderCreateModel : PageModel
    {
        private OrderManager orderManager = DependencyResolver.Instance.OrderManager;

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
        public IActionResult OnPostCreate(Guid id_order, Guid id_user, DateTime date)
        {
            orderManager.createOrder(id_order, id_user, date);
            return RedirectToPage("/Private/OrderList");
        }
    }
}