using Microsoft.AspNetCore.Mvc;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.TailorDtos;
using POS___Inventory_management.Mappers;
using POS___Inventory_management.Services.TailorServices;

namespace POS___Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TailorController : ControllerBase
    {
        private readonly ITailorAppService _tailorRepo;
        private readonly ApplicationDbContext _context;

        public TailorController(ApplicationDbContext context, ITailorAppService tailorRepo)
        {
            _tailorRepo = tailorRepo;
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var tailors = await _tailorRepo.GetAllAsync();
            var TailorDto = tailors.Select(s => s.ToTailorDto());

            return Ok(tailors);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Getbyid(int id)
        {
            var tailors = await _tailorRepo.GetByIdAsync(id);

            if (tailors == null)
            {
                return NotFound();
            }

            return Ok(tailors.ToTailorDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateTailorDto tailorDto)
        {
            var tailorModel = tailorDto.ToTailorFromCreateDto();
            var tailor = await _tailorRepo.CreateAsync(tailorModel);
            return CreatedAtAction(nameof(Getbyid), new { id = tailor.Id }, tailor.ToTailorDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTailorDto updateDto)
        {
            var tailorModel = await _tailorRepo.UpdateAsync(id, updateDto);

            if (tailorModel == null)
            {
                return NotFound();
            }

            return Ok(tailorModel.ToTailorDto());
        }

        [HttpDelete]

        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tailorModel = await _tailorRepo.DeleteAsync(id);

            if (tailorModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
