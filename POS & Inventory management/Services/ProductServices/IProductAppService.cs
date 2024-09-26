using POS___Inventory_management.Dtos.ProductDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services.ProductService
{
    public interface IProductAppService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int Id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product> UpdateAsync(int Id, UpdateProductDto productDto);
        Task<Product> DeleteAsync(int Id);
        Task<bool> ProductExists(int Id);
    }
}
