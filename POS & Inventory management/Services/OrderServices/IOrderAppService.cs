using POS___Inventory_management.Dtos.OrderDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services
{
    public interface IOrderAppService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int Id);
        Task<Order> CreateAsync(Order orderModel);
        Task<Order> UpdateAsync(int Id, UpdateOrderDto orderDto);
        Task<Order> DeleteAsync(int Id);
        Task<bool> OrderExists(int Id);
    }
}
