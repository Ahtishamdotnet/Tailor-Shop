using POS___Inventory_management.Dtos.OrderDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order entity)
        {
            return new OrderDto
            {
                ProductId = entity.ProductId,
                CustomerId = entity.CustomerId,
                TotalPrice = entity.TotalPrice,
                OrderStatus = entity.OrderStatus,
            };
        }

        public static Order ToOrderFromCreateDto(this CreateOrderDto orderDto)
        {
            return new Order
            {
                ProductId = orderDto.ProductId,
                CustomerId = orderDto.CustomerId,
                TotalPrice = orderDto.TotalPrice,
                OrderStatus = orderDto.OrderStatus,
            };
        }
    }
}
