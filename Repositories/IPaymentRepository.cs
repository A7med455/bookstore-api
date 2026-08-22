using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IPaymentRepository
    {
        List<Payment> GetAll();
        Payment? GetById(int PaymentId);
        Payment Create(Payment payment);
        bool Update(int PaymentId,Payment payment);
        bool Delete(int PaymentId);
    }
}