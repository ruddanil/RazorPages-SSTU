using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.OrderCRUD
{
    public class OrderListModel : PageModel
    {
        private OrderManager orderManager = DependencyResolver.Instance.OrderManager;
        public List<Order> orderList;
        public void OnGet()
        {
            orderList = orderManager.readAllOrders();
        }
        public void OnPostDelete(Guid id_order)
        {
            orderList = orderManager.readAllOrders();
            Order order = orderManager.readOrder(id_order);
            if (order != null)
            {
                orderManager.deleteOrder(id_order);
            }
            orderList = orderManager.readAllOrders();
        }
        
    }
}
