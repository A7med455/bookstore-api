using BookStoreAPI.DTOs.Customer;

namespace BookStoreAPI.Services
{
    public interface ICustomerService
    {
        public List<CustomerResponseDto> GetAll();
        public CustomerResponseDto? GetById(int CustomerId);
        public CustomerResponseDto Create(CustomerRegisterDto registerDto);
        public bool Update(int CustomerId,CustomerUpdateDto updateDto);
        public bool Delete(int CustomerId);
    }
}