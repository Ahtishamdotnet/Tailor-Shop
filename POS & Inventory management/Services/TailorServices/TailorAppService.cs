using Microsoft.EntityFrameworkCore;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.TailorDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services.TailorServices
{
    public class TailorAppService : ITailorAppService
    {
        private readonly ApplicationDbContext _context;

        public TailorAppService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Tailor> CreateAsync(Tailor tailorModel)
        {
            await _context.Tailors.AddAsync(tailorModel);
            await _context.SaveChangesAsync();
            return tailorModel;
        }

        public async Task<Tailor> DeleteAsync(int Id)
        {
            var tailorModel = await _context.Tailors.FirstOrDefaultAsync(x => x.Id == Id);
            if (tailorModel == null)
            {
                return null;
            }

            _context.Tailors.Remove(tailorModel);
            await _context.SaveChangesAsync();
            return tailorModel;

        }

        public async Task<List<Tailor>> GetAllAsync()
        {
            return await _context.Tailors.ToListAsync();
        }

        public async Task<Tailor> GetByIdAsync(int Id)
        {
            return await _context.Tailors.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public Task<bool> TailorExists(int id)
        {
            return _context.Tailors.AnyAsync(s => s.Id == id);
        }

        public async Task<Tailor> UpdateAsync(int Id, UpdateTailorDto tailorDto)
        {
            var existingTailor = await _context.Tailors.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingTailor == null)
            {
                return null;
            }

            existingTailor.Name = tailorDto.Name;
            existingTailor.PhnNo = tailorDto.PhnNo;
            existingTailor.Address = tailorDto.Address;

            await _context.SaveChangesAsync();

            return existingTailor;

        }

    }
}
