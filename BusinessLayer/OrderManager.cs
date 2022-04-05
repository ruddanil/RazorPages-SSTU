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
        public Guid createOrder(Guid id_order, Guid id_user, DateTime date)
        {
            Order order = new Order(id_order, id_user, date);
            Guid id = orderRepository.CreateOrder(order);
            return id;
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
