using Microsoft.AspNetCore.Mvc;
using POS___Inventory_management.Dtos.UserDtos;
using POS___Inventory_management.Mappers;
using POS___Inventory_management.Services;

namespace POS___Inventory_management.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _confi;
        private readonly IUserAppService _userRepo;

        public UserController(IConfiguration confi, IUserAppService userRepo)
        {
            _confi = confi;
            _userRepo = userRepo;
        }

        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromBody] CreateUserDto userRegistrationDto)
        {
            var userModel = userRegistrationDto.ToUserFromCreate();
            var user = await _userRepo.CreateAsync(userModel);

            return Ok(userModel);
        }
    }
}
