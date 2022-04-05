using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.OrderCRUD
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
        public void OnPostCreate (Guid id_order, string title, int quantity, decimal price, string description)
        {
            //orderManager.createOrder(id_order, title, quantity, price, description);
            //return RedirectToPage("/OrderCRUD/OrderList");
        }
    }
}
