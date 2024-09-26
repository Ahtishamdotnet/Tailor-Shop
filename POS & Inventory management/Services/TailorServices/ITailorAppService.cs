using POS___Inventory_management.Dtos.TailorDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services.TailorServices
{
    public interface ITailorAppService
    {
        Task<List<Tailor>> GetAllAsync();
        Task<Tailor> GetByIdAsync(int Id);
        Task<Tailor> CreateAsync(Tailor tailorModel);
        Task<Tailor> UpdateAsync(int Id, UpdateTailorDto tailorDto);
        Task<Tailor> DeleteAsync(int Id);
        Task<bool> TailorExists(int Id);
    }
}
