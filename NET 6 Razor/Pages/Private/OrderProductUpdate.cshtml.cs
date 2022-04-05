using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class OrderProductUpdateModel : PageModel
    {
        private OrderProductManager orderProductManager = DependencyResolver.Instance.OrderProductManager;
        public OrderProduct orderProduct;
        public OrderProduct updatedOrderProduct;
        public IActionResult OnGet(Guid id_orderProduct)
        {
            orderProduct = orderProductManager.readOrderProduct(id_orderProduct);
            return Page();
        }
        public IActionResult OnPost(Guid id_orderProduct)
        {
            orderProduct = orderProductManager.readOrderProduct(id_orderProduct);
            return Page();
        }
        public IActionResult OnPostUpdate(Guid id_orderProduct, Guid id_order, Guid id_product, int quantity, decimal pricePerUnit)
        {
            orderProduct = orderProductManager.readOrderProduct(id_order);
            OrderProduct updatedOrderProduct = new(id_orderProduct, id_order, id_product, quantity, pricePerUnit);
            orderProductManager.updateOrderProduct(updatedOrderProduct);
            return RedirectToPage("/Private/OrderProductList");
        }
    }
}
