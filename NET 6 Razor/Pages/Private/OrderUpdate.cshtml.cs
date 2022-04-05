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
        //public IActionResult OnPostUpdate(Guid id_order, string title, int quantity, decimal price, string description)
        //{
        //    order = orderManager.readOrder(id_order);
        //    Order updatedOrder = new(id_order, title, quantity, price, description);
        //    orderManager.updateOrder(updatedOrder);
        //    return RedirectToPage("/OrderCRUD/OrderList");
        //}
    }
}
