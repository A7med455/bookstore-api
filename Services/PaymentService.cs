using BookStoreAPI.DTOs.Payment;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;

namespace BookStoreAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IOrderRepository orderRepository,IPaymentRepository paymentRepository)
        {
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }

        private PaymentResponseDto MapToResponse(Payment payment)
        {
            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                TransactionDate = payment.TransactionDate,
                TransactionReference = payment.TransactionReference
            };
        }
        public PaymentResponseDto Create(PaymentCreateDto dto)
        {
            Order? order = _orderRepository.GetById(dto.OrderId);
            if(order == null)
            {
                throw new ArgumentException("Order not found");
            }
            decimal totalAmount = 0;
            foreach(OrderItem item in order.Items)
            {
                totalAmount += item.PriceAtPurchase * item.Quantity;
            }
            Payment newPayment = new Payment
            {
                OrderId = dto.OrderId,
                Amount = totalAmount,
                PaymentMethod = dto.PaymentMethod,
                PaymentStatus = PaymentStatus.Pending,
                TransactionDate = DateTime.UtcNow,
                TransactionReference = null
            };
            Payment CreatedPayment = _paymentRepository.Create(newPayment);
            return MapToResponse(CreatedPayment);
        }

        public List<PaymentResponseDto> GetAll()
        {
            List<Payment> payments = _paymentRepository.GetAll();
            List<PaymentResponseDto> result = new List<PaymentResponseDto>();
            foreach (Payment payment in payments)
            {
                result.Add(MapToResponse(payment));
            }
            return result;
        }

        public PaymentResponseDto? GetById(int PaymentId)
        {
            Payment? payment = _paymentRepository.GetById(PaymentId);
            if (payment == null)
            {
                return null;
            }
            return MapToResponse(payment);
        }

        public bool UpdateStatus(int PaymentId, PaymentUpdateDto dto)
        {
            Payment? existingPayment = _paymentRepository.GetById(PaymentId);
            if (existingPayment == null)
            {
                return false;
            }

            if (dto.PaymentStatus.HasValue)
            {
                existingPayment.PaymentStatus = dto.PaymentStatus.Value;
            }
            if (dto.TransactionReference != null)
            {
                existingPayment.TransactionReference = dto.TransactionReference;
            }

            _paymentRepository.Update(PaymentId, existingPayment);
            return true;
        }
    }
}
