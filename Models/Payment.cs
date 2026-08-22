
namespace BookStoreAPI.Models
{
    public enum PaymentMethod
    {//only one payment method for now
        CreditCard
    }
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded   
    }
    public class Payment
    {
        public int PaymentId{ get; set;}
        public required int OrderId{ get; set;}
        public required decimal Amount{ get; set;}
        public required PaymentMethod PaymentMethod{ get; set;}
        public required PaymentStatus PaymentStatus{ get; set;}
        public required DateTime TransactionDate{ get; set;}
        public string? TransactionReference { get; set; }
        
    }
}