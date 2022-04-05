using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Public
{
    public class ProductListUserModel : PageModel
    {
        private ProductManager productManager = DependencyResolver.Instance.ProductManager;
        public List<Product> productList;
        public void OnGet()
        {
            productList = productManager.readAllProducts();
        }
    }
}
 
