using BusinessLayer;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_6_Razor.Pages.Private
{
    public class ProductListModel : PageModel
    {
        private ProductManager productManager = DependencyResolver.Instance.ProductManager;
        public List<Product> productList;
        public void OnGet()
        {
            productList = productManager.readAllProducts();
        }
        public void OnPostDelete(Guid id_product)
        {
            productList = productManager.readAllProducts();
            Product product = productManager.readProduct(id_product);
            if (product != null)
            {
                productManager.deleteProduct(id_product);
            }
            productList = productManager.readAllProducts();
        }
        
    }
}
