using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class OrderProductCreateModel : PageModel
    {
        private OrderProductManager orderProductManager = DependencyResolver.Instance.OrderProductManager;

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
        public IActionResult OnPostCreate(Guid id_orderProduct, Guid id_order, Guid id_product, int quantity, decimal pricePerUnit)
        {
            orderProductManager.createOrderProduct(id_orderProduct, id_order, id_product, quantity, pricePerUnit);
            return RedirectToPage("/Private/OrderProductList");
        }
    }
}
