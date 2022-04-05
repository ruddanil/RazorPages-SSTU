using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class ProductUpdateModel : PageModel
    {
        private ProductManager productManager = DependencyResolver.Instance.ProductManager;
        public Product product;
        public Product updatedProduct;
        public IActionResult OnGet(Guid id_product)
        {
            product = productManager.readProduct(id_product);
            return Page();
        }
        public IActionResult OnPost(Guid id_product)
        {
            product = productManager.readProduct(id_product);
            return Page();
        }
        public IActionResult OnPostUpdate(Guid id_product, string title, int quantity, decimal price, string description)
        {
            product = productManager.readProduct(id_product);
            Product updatedProduct = new(id_product, title, quantity, price, description);
            productManager.updateProduct(updatedProduct);
            return RedirectToPage("/Private/ProductList");
        }
    }
}
