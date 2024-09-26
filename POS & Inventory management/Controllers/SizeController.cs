using Microsoft.AspNetCore.Mvc;
using POS___Inventory_management.Dtos.SizeDtos;
using POS___Inventory_management.Mappers;
using POS___Inventory_management.Services;
using POS___Inventory_management.Services.SizeServices;

namespace POS___Inventory_management.Controllers
{
    [Route("api/size")]
    [ApiController]
    public class SizeControllers : ControllerBase
    {
        private readonly ISizeAppService _sizeRepo;
        private readonly ICustomerAppService _customerRepo;

        public SizeControllers(ISizeAppService sizeRepo, ICustomerAppService customerRepo)
        {
            _sizeRepo = sizeRepo;
            _customerRepo = customerRepo;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var sizes = await _sizeRepo.GetAllAsync();
            var SizeDto = sizes.Select(s => s.ToSizeDto());

            return Ok(SizeDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Getbyid([FromRoute] int id)
        {
            var sizes = await _sizeRepo.GetByIdAsync(id);

            if (sizes == null)
            {
                return NotFound();
            }

            return Ok(sizes.ToSizeDto());
        }

        [HttpPost("create/{customerId}")]

        public async Task<IActionResult> Create(int customerId, [FromBody] CreateSizeDto sizeDto)
        {
            if (!await _customerRepo.CustomerExists(customerId))
            {
                return BadRequest("Customer Does Not Exist");
            }
            var sizeModel = sizeDto.ToSizeFromCreate(customerId);
            await _sizeRepo.CreateAsync(sizeModel);
            return CreatedAtAction(nameof(Getbyid), new { id = sizeModel.Id }, sizeModel.ToSizeDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSizeDto updateDto)
        {
            var size = await _sizeRepo.UpdateAsync(id, updateDto.ToSizeFromUpdate());

            if (size == null)
            {
                return NotFound("Size not found");
            }

            return Ok(size.ToSizeDto());
        }

        [HttpDelete]

        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var sizeModel = await _sizeRepo.DeleteAsync(id);

            if (sizeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
