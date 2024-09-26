using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services
{
    public interface IUserAppService
    {
        Task<User> CreateAsync(User userModel);
    }
}
