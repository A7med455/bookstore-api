using BookStoreAPI.DTOs.Customer;

namespace BookStoreAPI.Services
{
    public interface ICustomerService
    {
        public Task<List<CustomerResponseDto>> GetAll();
        public Task<CustomerResponseDto?> GetById(int CustomerId);
        public Task<CustomerResponseDto> Create(CustomerRegisterDto registerDto);
        public Task<bool> Update(int CustomerId,CustomerUpdateDto updateDto);
        public Task<bool> Delete(int CustomerId);
    }
}