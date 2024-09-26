using POS___Inventory_management.Data;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly ApplicationDbContext _context;
        public UserAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

    }
}
