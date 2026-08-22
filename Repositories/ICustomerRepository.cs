using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer? GetById(int customerId);
        Customer Create(Customer customer);
        bool Update(int customerId, Customer customer);
        bool Delete(int customerId);
    }
}