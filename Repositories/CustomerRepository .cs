using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAll() => _context.Customers.ToList();

        public Customer? GetById(int customerId) => _context.Customers.Find(customerId);

        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public bool Update(int customerId, Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customerId);
            if (existingCustomer == null)
            {
                return false;
            }
            existingCustomer.AccountUserName = customer.AccountUserName;
            existingCustomer.Name = customer.Name;
            existingCustomer.Age = customer.Age;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int customerId)
        {
            var existingCustomer = _context.Customers.Find(customerId);
            if (existingCustomer == null) 
            {
                return false;
            }
            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();
            return true;
        }
    }
}