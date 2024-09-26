using Microsoft.AspNetCore.Mvc;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.CustomerDtos;
using POS___Inventory_management.Mappers;
using POS___Inventory_management.Services;

namespace POS___Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerRepo;
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context, ICustomerAppService customerRepo)
        {
            _customerRepo = customerRepo;
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerRepo.GetAllAsync();
            var CustomerDto = customers.Select(s => s.ToCustomerDto());

            return Ok(customers);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Getbyid(int id)
        {
            var customers = await _customerRepo.GetByIdAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers.ToCustomerDto());
        }

        [HttpPost("create")]

        public async Task<IActionResult> Create([FromBody] CreateCustomerDto customerDto)
        {
            var customerModel = customerDto.ToCustomerFromCreateDto();
            var customer = await _customerRepo.CreateAsync(customerModel);
            return CreatedAtAction(nameof(Getbyid), new { id = customer.Id }, customer.ToCustomerDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerDto updateDto)
        {
            var customerModel = await _customerRepo.UpdateAsync(id, updateDto);

            if (customerModel == null)
            {
                return NotFound();
            }

            return Ok(customerModel.ToCustomerDto());
        }

        [HttpDelete]

        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customerModel = await _customerRepo.DeleteAsync(id);

            if (customerModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
