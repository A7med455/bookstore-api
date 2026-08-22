using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order? GetById(int OrderId)
        {
            return _context.Orders.Find(OrderId);
        }

        public Order Create(Order order, List<OrderItem> items)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (var item in items)
            {
                item.OrderId = order.OrderId;
                _context.OrderItems.Add(item);
            }
            _context.SaveChanges();
            return order;
        }

        public bool Update(int OrderId, Order order)
        {
            var existingOrder = _context.Orders.Find(OrderId);
            if (existingOrder == null)
            {
                return false;
            }
            existingOrder.OrderStatus = order.OrderStatus;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int OrderId)
        {
            var existingOrder = _context.Orders.Find(OrderId);
            if (existingOrder == null)
            {
                return false;
            }
            _context.Orders.Remove(existingOrder);
            _context.SaveChanges();
            return true;
        }
    }
}