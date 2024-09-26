using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services.SizeServices
{
    public interface ISizeAppService
    {
        Task<Size> CreateAsync(Size sizeModel);
        Task<Size?> DeleteAsync(int Id);
        Task<List<Size>> GetAllAsync();
        Task<Size?> GetByIdAsync(int Id);
        Task<Size?> UpdateAsync(int Id, Size sizeModel);
    }
}
