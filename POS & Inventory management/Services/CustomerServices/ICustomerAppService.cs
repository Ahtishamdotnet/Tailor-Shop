using POS___Inventory_management.Dtos.CustomerDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services
{
    public interface ICustomerAppService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int Id);
        Task<Customer> CreateAsync(Customer customerModel);
        Task<Customer> UpdateAsync(int Id, UpdateCustomerDto customerDto);
        Task<Customer> DeleteAsync(int Id);
        Task<bool> CustomerExists(int Id);
    }
}
