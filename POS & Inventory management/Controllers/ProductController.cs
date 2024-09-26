using Microsoft.AspNetCore.Mvc;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.ProductDtos;
using POS___Inventory_management.Mappers;
using POS___Inventory_management.Services.ProductService;

namespace POS___Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productRepo;
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context, IProductAppService productRepo)
        {
            _productRepo = productRepo;
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepo.GetAllAsync();
            var ProductDto = products.Select(s => s.ToProductDto());

            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Getbyid(int id)
        {
            var products = await _productRepo.GetByIdAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products.ToProductDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
        {
            var productModel = productDto.ToProductFromCreateDto();
            var product = await _productRepo.CreateAsync(productModel);
            return CreatedAtAction(nameof(Getbyid), new { id = product.Id }, product.ToProductDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto updateDto)
        {
            var productModel = await _productRepo.UpdateAsync(id, updateDto);

            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel.ToProductDto());
        }

        [HttpDelete]

        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var productModel = await _productRepo.DeleteAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
