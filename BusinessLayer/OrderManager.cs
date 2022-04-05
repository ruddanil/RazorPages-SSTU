using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderManager
    {
        private OrderRepository orderRepository;
        public OrderManager(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public void createOrder(Guid id_order, Guid id_user, Guid id_product, string description, DateTime date)
        {
            Order order = new Order(id_order, id_user, id_product, description, date);
            orderRepository.CreateOrder(order);
        }
        public Order readOrder(Guid id_order)
        {
            return orderRepository.ReadOrder(id_order);
        }
        public void updateOrder(Order order)
        {
            orderRepository.UpdateOrder(order);
        }
        public void deleteOrder(Guid id_order)
        {
            Order order = orderRepository.ReadOrder(id_order);
            orderRepository.DeleteOrder(order);
        }
        public List<Order> readAllOrders()
        {
            return orderRepository.ReadAllOrders();
        }
    }
}
