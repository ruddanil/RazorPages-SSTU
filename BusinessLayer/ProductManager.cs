using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Entity;

namespace BusinessLayer
{
    public class ProductManager
    {
        private ProductRepository productRepository;

        public ProductManager(ProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public void createProduct(Guid id_product, string title, int quantity, decimal price, string description)
        {
            Product product = new Product(id_product, title, quantity, price, description);
            productRepository.CreateProduct(product);
        }
        public Product readProduct(Guid id_product)
        {
            return productRepository.ReadProduct(id_product);
        }
        public void updateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }
        public void deleteProduct(Guid id_product)
        {
            Product product = productRepository.ReadProduct(id_product);
            productRepository.DeleteProduct(product);
        }
        public List<Product> readAllProducts()
        {
            return productRepository.ReadAllProducts();
        }
    }
}
