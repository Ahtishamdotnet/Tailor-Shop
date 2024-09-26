using Microsoft.EntityFrameworkCore;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.ProductDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Services.ProductService
{
    public class ProductAppService : IProductAppService
    {
        private readonly ApplicationDbContext _context;

        public ProductAppService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product> DeleteAsync(int Id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (productModel == null)
            {
                return null;
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;

        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public Task<bool> ProductExists(int id)
        {
            return _context.Products.AnyAsync(s => s.Id == id);
        }

        public async Task<Product> UpdateAsync(int Id, UpdateProductDto productDto)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Price = productDto.Price;
            existingProduct.ProductType = productDto.ProductType;


            await _context.SaveChangesAsync();

            return existingProduct;

        }
    }
}
