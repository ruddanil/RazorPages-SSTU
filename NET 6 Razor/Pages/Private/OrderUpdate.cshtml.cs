using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class OrderUpdateModel : PageModel
    {
        private OrderManager orderManager = DependencyResolver.Instance.OrderManager;
        public Order order;
        public Order updatedOrder;
        public IActionResult OnGet(Guid id_order)
        {
            order = orderManager.readOrder(id_order);
            return Page();
        }
        public IActionResult OnPost(Guid id_order)
        {
            order = orderManager.readOrder(id_order);
            return Page();
        }
        public IActionResult OnPostUpdate(Guid id_order, Guid id_user, DateTime date)
        {
            order = orderManager.readOrder(id_order);
            Order updatedOrder = new(id_order, id_user, date);
            orderManager.updateOrder(updatedOrder);
            return RedirectToPage("/Private/OrderList");
        }
    }
}
