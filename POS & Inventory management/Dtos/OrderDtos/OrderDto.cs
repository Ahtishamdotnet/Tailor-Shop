using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
