using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll() => await _context.Customers.ToListAsync();

        public async Task<Customer?> GetById(int customerId) => await _context.Customers.FindAsync(customerId);

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> Update(int customerId, Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customerId);
            if (existingCustomer == null)
            {
                return false;
            }
            existingCustomer.AccountUserName = customer.AccountUserName;
            existingCustomer.Name = customer.Name;
            existingCustomer.Age = customer.Age;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int customerId)
        {
            var existingCustomer = await _context.Customers.FindAsync(customerId);
            if (existingCustomer == null) 
            {
                return false;
            }
            _context.Customers.Remove(existingCustomer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}