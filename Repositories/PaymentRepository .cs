using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }

        public Payment? GetById(int PaymentId)
        {
            return _context.Payments.Find(PaymentId);
        }

        public Payment Create(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public bool Update(int PaymentId,Payment payment)
        {
            var existingPayment = _context.Payments.Find(PaymentId);
            if(existingPayment == null)
            {
                return false;
            }
            existingPayment.PaymentStatus = payment.PaymentStatus;
            existingPayment.TransactionReference = payment.TransactionReference;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int PaymentId)
        {
            var existingPayment = _context.Payments.Find(PaymentId);
            if(existingPayment == null)
            {
                return false;
            }
            _context.Payments.Remove(existingPayment);
            _context.SaveChanges();
            return true;
        }
    }
}