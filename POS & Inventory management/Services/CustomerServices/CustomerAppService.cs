using Microsoft.EntityFrameworkCore;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.CustomerDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ApplicationDbContext _context;

        public CustomerAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateAsync(Customer customerModel)
        {
            await _context.Customers.AddAsync(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;
        }

        public async Task<Customer> DeleteAsync(int Id)
        {
            var customerModel = await _context.Customers.FirstOrDefaultAsync(x => x.Id == Id);
            if (customerModel == null)
            {
                return null;
            }

            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;

        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int Id)
        {
            return await _context.Customers.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public Task<bool> CustomerExists(int Id)
        {
            return _context.Customers.AnyAsync(s => s.Id == Id);
        }

        public async Task<Customer> UpdateAsync(int Id, UpdateCustomerDto customerDto)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Name = customerDto.Name;
            existingCustomer.PhoneNo = customerDto.PhoneNo;
            existingCustomer.Address = customerDto.Address;

            await _context.SaveChangesAsync();

            return existingCustomer;

        }
    }
}
