using BookStoreAPI.DTOs.Order;
using BookStoreAPI.DTOs.OrderItem;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;

namespace BookStoreAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        public OrderService(IOrderRepository orderRepository,IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }
        private OrderResponseDto MapToResponse(Order order)
        {
            List<OrderItemResponseDto> itemDtos = new List<OrderItemResponseDto>();
            foreach(OrderItem item in order.Items)
            {
                itemDtos.Add(new OrderItemResponseDto
                {
                    ItemId = item.ItemId,
                    BookId = item.BookId,
                    Quantity = item.Quantity,
                    PriceAtPurchase = item.PriceAtPurchase
                });
            }
            return new OrderResponseDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                OrderedItems = itemDtos
            };
        }
        public OrderResponseDto Create(OrderCreateDto dto)
        {
            List<OrderItem> items =new List<OrderItem>();
            foreach(OrderItemCreateDto itemDto in dto.OrderedItems)
            {
                Book? book = _bookRepository.GetById(itemDto.BookId);
                if(book == null)
                {
                    throw new ArgumentException($"Book with ID {itemDto.BookId} not found");
                }
                OrderItem newItem = new OrderItem
                {
                  OrderId = 0, // placeholder , the real value gets set when order is saved 
                  BookId = itemDto.BookId,
                  Quantity = itemDto.Quantity,
                  PriceAtPurchase = book.Price  
                };
                items.Add(newItem);
            }
            
            Order newOrder = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = Status.Pending
            };

            Order CreatedOrder = _orderRepository.Create(newOrder,items);
            Order? OrderWithItems = _orderRepository.GetById(CreatedOrder.OrderId);
            return MapToResponse(OrderWithItems!);
        }
        public List<OrderResponseDto> GetAll()
        {
            List<Order> orders = _orderRepository.GetAll();
            List<OrderResponseDto> result = new List<OrderResponseDto>();
            foreach(Order order in orders)
            {
                result.Add(MapToResponse(order));
            }
            return result;
        }
        public OrderResponseDto? GetById(int OrderId)
        {
            Order? order = _orderRepository.GetById(OrderId);
            if(order == null)
            {
                return null;   
            }
            return MapToResponse(order);
        }
        public bool UpdateStatus(int OrderId,Status newStatus)
        {
            Order? ExistingOrder = _orderRepository.GetById(OrderId);
            if(ExistingOrder == null)
            {
                return false;
            }
            ExistingOrder.OrderStatus = newStatus;
            _orderRepository.Update(OrderId,ExistingOrder);
            return true;
        }
    }
}