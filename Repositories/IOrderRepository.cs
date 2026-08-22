using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order? GetById(int OrderId);
        Order Create(Order order, List<OrderItem> items);
        bool Update(int OrderId, Order order);
        bool Delete(int OrderId);
    }
}