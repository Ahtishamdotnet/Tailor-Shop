using Microsoft.AspNetCore.Mvc;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.OrderDtos;
using POS___Inventory_management.Mappers;
using POS___Inventory_management.Entities;
using POS___Inventory_management.Services;

namespace POS___Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderRepo;
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context, IOrderAppService orderRepo)
        {
            _orderRepo = orderRepo;
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderRepo.GetAllAsync();
            var OrderDto = orders.Select(s => s.ToOrderDto());

            return Ok(orders);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Getbyid(int id)
        {
            var orders = await _orderRepo.GetByIdAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders.ToOrderDto());
        }

        [HttpGet("statuslist")]
        public IActionResult GetStatusList()
        {
            var statuses = Enum.GetValues(typeof(OrderStatus))
                               .Cast<OrderStatus>()
                               .Select(s => new { Id = (int)s, Name = s.ToString() })
                               .ToList();

            return Ok(statuses);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateOrderDto orderDto)
        {
            var orderModel = orderDto.ToOrderFromCreateDto();
            var order = await _orderRepo.CreateAsync(orderModel);
            return CreatedAtAction(nameof(Getbyid), new { id = order.Id }, order.ToOrderDto());
        }

        [HttpPost("updatestatus")]

        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusDto dto)
        {
            var order = await _context.Orders.FindAsync(dto.OrderId);

            if (order == null)
            {
                return NotFound(new { message = "Order not found." });
            }

            if (!Enum.IsDefined(typeof(OrderStatus), dto.OrderStatus))
            {
                return BadRequest(new { message = "Invalid order status." });
            }

            order.OrderStatus = (OrderStatus)dto.OrderStatus;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Order status updated successfully." });
        }

        [HttpPost("assignOrder")]

        public async Task<IActionResult> AssignOrderToTailor([FromBody] AssignOrderDto assignOrderDto)
        {
            var order = await _context.Orders.FindAsync(assignOrderDto.OrderId);
            if (order == null)
            {
                return NotFound(new { message = $"Order with ID {assignOrderDto.OrderId} not found." });
            }

            var tailor = await _context.Tailors.FindAsync(assignOrderDto.TailorId);
            if (tailor == null)
            {
                return NotFound(new { message = $"Tailor with ID {assignOrderDto.TailorId} not found." });
            }

            tailor.OrderId = assignOrderDto.OrderId;
            await _context.SaveChangesAsync();
            return Ok(new { message = $"Order {assignOrderDto.OrderId} assigned to Tailor {assignOrderDto.TailorId}." });
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderDto updateDto)
        {
            var orderModel = await _orderRepo.UpdateAsync(id, updateDto);

            if (orderModel == null)
            {
                return NotFound();
            }

            return Ok(orderModel.ToOrderDto());
        }

        [HttpDelete]

        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var orderModel = await _orderRepo.DeleteAsync(id);

            if (orderModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
