using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Entity;
using BusinessLayer;

namespace NET_6_Razor.Pages.Public
{
    public class CartModel : PageModel
    {
        private ProductManager productManager = DependencyResolver.Instance.ProductManager;
        private OrderManager orderManager = DependencyResolver.Instance.OrderManager;
        private OrderProductManager orderProductManager = DependencyResolver.Instance.OrderProductManager;
        Product product;
        Order order;

        public List<Item> cart { get; set; }
        public decimal Total { get; set; }


        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                Total = cart.Sum(i => i.Product.Price * i.Quantity);
            }
        }

        public IActionResult OnGetBuyNow(Guid id_product)
        {
            product = productManager.readProduct(id_product);
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item
                {
                    Product = product,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id_product);
                if (index == -1)
                {
                    cart.Add(new Item
                    {
                        Product = productManager.readProduct(id_product),
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("/Public/Cart");
        }

        public IActionResult OnGetDelete(Guid id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("/Public/Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("/Public/Cart");
        }

        public IActionResult OnPostCreateOrder(Guid id, Guid id_orderProduct)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            string? id_user = HttpContext.Session.GetString("id");
            if (id_user == null) throw new ArgumentNullException(nameof(id_user));
            DateTime date = DateTime.Now;

            Guid id_order = orderManager.createOrder(id, new Guid(id_user), date);

            order = orderManager.readOrder(id);

            for (var i = 0; i < cart.Count; i++)
            {
                OrderProduct orderProduct;
                Product product = cart[i].Product;
                Guid id_product = product.ID_product;
                int quantity = cart[i].Quantity;
                decimal pricePerUnit = product.Price;
                orderProductManager.createOrderProduct(id_orderProduct, id_order, id_product, quantity, pricePerUnit);
            }
            for (var i = 0; i < cart.Count; i++)
            {
                cart.RemoveAt(i);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("/Public/ProductListUser");
        }

        public void OnPost()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        }

        private int Exists(List<Item> cart, Guid id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ID_product == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
