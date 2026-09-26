using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer?> GetById(int customerId);
        Task<Customer> Create(Customer customer);
        Task<bool> Update(int customerId, Customer customer);
        Task<bool> Delete(int customerId);
    }
}