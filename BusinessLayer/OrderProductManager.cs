using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderProductManager
    {
        private OrderProductRepository orderProductRepository;
        public OrderProductManager(OrderProductRepository orderProductRepository)
        {
            this.orderProductRepository = orderProductRepository ?? throw new ArgumentNullException(nameof(orderProductRepository));
        }
        public void createOrderProduct(Guid id_orderProduct, Guid id_order, Guid id_product, int quantity, decimal pricePerUnit)
        {
            OrderProduct orderProduct = new OrderProduct(id_orderProduct, id_order, id_product, quantity, pricePerUnit);
            orderProductRepository.CreateOrderProduct(orderProduct);
        }
        public OrderProduct readOrderProduct(Guid id_orderProduct)
        {
            return orderProductRepository.ReadOrderProduct(id_orderProduct);
        }
        public void updateOrderProduct(OrderProduct orderProduct)
        {
            orderProductRepository.UpdateOrderProduct(orderProduct);
        }
        public void deleteOrderProduct(Guid id_orderProduct)
        {
            OrderProduct orderProduct = orderProductRepository.ReadOrderProduct(id_orderProduct);
            orderProductRepository.DeleteOrderProduct(orderProduct);
        }
        public List<OrderProduct> readAllOrderProducts()
        {
            return orderProductRepository.ReadAllOrderProducts();
        }
    }
}
