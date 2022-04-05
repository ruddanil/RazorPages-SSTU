using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class ProductCreateModel : PageModel
    {
        private ProductManager productManager = DependencyResolver.Instance.ProductManager;

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
        public IActionResult OnPostCreate (Guid id_product, string title, int quantity, decimal price, string description)
        {
            productManager.createProduct(id_product, title, quantity, price, description);
            return RedirectToPage("/Private/ProductList");
        }
    }
}
