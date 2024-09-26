using Microsoft.EntityFrameworkCore;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.OrderDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly ApplicationDbContext _context;

        public OrderAppService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Order> CreateAsync(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<Order> DeleteAsync(int Id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.Id == Id);
            if (orderModel == null)
            {
                return null;
            }

            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;

        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int Id)
        {
            return await _context.Orders.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public Task<bool> OrderExists(int id)
        {
            return _context.Orders.AnyAsync(s => s.Id == id);
        }

        public async Task<Order> UpdateAsync(int Id, UpdateOrderDto orderDto)
        {
            var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.CustomerId = orderDto.CustomerId;
            existingOrder.ProductId = orderDto.ProductId;
            existingOrder.TotalPrice = orderDto.TotalPrice;
            existingOrder.OrderStatus = orderDto.OrderStatus;

            await _context.SaveChangesAsync();

            return existingOrder;

        }

    }
}
