using Microsoft.EntityFrameworkCore;
using POS___Inventory_management.Data;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services.SizeServices
{
    public class SizeAppService : ISizeAppService
    {
        private readonly ApplicationDbContext _context;

        public SizeAppService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Size> CreateAsync(Size sizeModel)
        {
            await _context.Sizes.AddAsync(sizeModel);
            await _context.SaveChangesAsync();
            return sizeModel;

        }

        public async Task<Size?> DeleteAsync(int Id)
        {
            var sizeModel = await _context.Sizes.FirstOrDefaultAsync(x => x.Id == Id);
            if (sizeModel == null)
            {
                return null;
            }

            _context.Sizes.Remove(sizeModel);
            await _context.SaveChangesAsync();
            return sizeModel;

        }

        public async Task<List<Size>> GetAllAsync()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size?> GetByIdAsync(int Id)
        {
            return await _context.Sizes.FindAsync(Id);
        }

        public async Task<Size?> UpdateAsync(int Id, Size sizeModel)
        {
            var existingSize = await _context.Sizes.FindAsync(Id);

            if (existingSize == null)
            {
                return null;
            }

            existingSize.Chest = sizeModel.Chest;
            existingSize.Colar = sizeModel.Colar;
            existingSize.Waist = sizeModel.Waist;
            existingSize.Shoulder = sizeModel.Shoulder;
            existingSize.Sleeve = sizeModel.Sleeve;
            existingSize.TopLength = sizeModel.TopLength;
            existingSize.BottomLeg = sizeModel.BottomLeg;
            existingSize.BottomLength = sizeModel.BottomLength;
            existingSize.Description = sizeModel.Description;

            await _context.SaveChangesAsync();

            return existingSize;
        }
    }
}
