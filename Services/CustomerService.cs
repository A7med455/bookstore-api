using BookStoreAPI.DTOs.Customer;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        public CustomerService(ICustomerRepository customerRepository,IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        private CustomerResponseDto MapToResponse(Customer customer)
        {
            return new CustomerResponseDto
            {
                CustomerId = customer.CustomerId,
                AccountUserName = customer.AccountUserName,
                Name = customer.Name,
                Age = customer.Age
            };
        }
        public CustomerResponseDto Create(CustomerRegisterDto registerDto)
        {
            var hasher = new PasswordHasher<User>();
            string hashedPassword = hasher.HashPassword(null!,registerDto.Password);
            User NewUser = new User
            {
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                Role = Role.Customer
            };
            User CreatedUser = _userRepository.Create(NewUser);
            Customer NewCustomer = new Customer
            {
                UserId = CreatedUser.UserId,
                Name = registerDto.Name,
                AccountUserName = registerDto.AccountUserName,
                Age = registerDto.Age
            };
            Customer ExistingCustomer = _customerRepository.Create(NewCustomer);
            return MapToResponse(ExistingCustomer);
        }
        public List<CustomerResponseDto> GetAll()
        {
            List<Customer> customers = _customerRepository.GetAll();
            List<CustomerResponseDto> ExistingCustomer = new List<CustomerResponseDto>();
            foreach(Customer customer in customers)
            {
                ExistingCustomer.Add(MapToResponse(customer));
            }
            return ExistingCustomer;
        }
        public CustomerResponseDto? GetById(int CustomerId)
        {
            Customer? ExistingCustomer = _customerRepository.GetById(CustomerId);
            if(ExistingCustomer == null)
            {
                return null;
            }
            return MapToResponse(ExistingCustomer);
        }
        public bool Update(int CustomerId,CustomerUpdateDto updateDto)
        {
            Customer? ExistingCustomer = _customerRepository.GetById(CustomerId);
            if(ExistingCustomer == null)
            {
                return false;
            }
            if(updateDto.AccountUserName != null && string.IsNullOrWhiteSpace(updateDto.AccountUserName))
            {
                throw new ArgumentException("AccountUserName cannot be empty");
            }
            if(updateDto.Name != null && string.IsNullOrWhiteSpace(updateDto.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if(updateDto.AccountUserName !=  null)
            {
                ExistingCustomer.AccountUserName = updateDto.AccountUserName;
            }
            if(updateDto.Name != null)
            {
                ExistingCustomer.Name = updateDto.Name;
            }
            if(updateDto.Age.HasValue)
            {
                ExistingCustomer.Age = updateDto.Age.Value;
            }
            _customerRepository.Update(CustomerId,ExistingCustomer);
            return true;
        }
        public bool Delete(int CustomerId)
        {
            Customer? ExistingCustomer = _customerRepository.GetById(CustomerId);
            if(ExistingCustomer == null)
            {
                return false;
            }
            return _customerRepository.Delete(CustomerId);
        }
    }
}