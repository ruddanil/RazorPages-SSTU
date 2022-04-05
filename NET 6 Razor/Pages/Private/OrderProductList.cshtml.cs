using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class OrderProductListModel : PageModel
    {
        private OrderProductManager orderProductManager = DependencyResolver.Instance.OrderProductManager;
        public List<OrderProduct> orderProductList;
        public void OnGet()
        {
            orderProductList = orderProductManager.readAllOrderProducts();
        }
        public void OnPostDelete(Guid id_order)
        {
            orderProductList = orderProductManager.readAllOrderProducts();
            OrderProduct orderProduct = orderProductManager.readOrderProduct(id_order);
            if (orderProduct != null)
            {
                orderProductManager.deleteOrderProduct(id_order);
            }
            orderProductList = orderProductManager.readAllOrderProducts();
        }
    }
}
