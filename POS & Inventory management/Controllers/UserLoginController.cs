using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using POS___Inventory_management.Data;
using POS___Inventory_management.Dtos.UserDtos;
using POS___Inventory_management.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace POS___Inventory_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IConfiguration _confi;

        public UserLoginController(IConfiguration confi, ApplicationDbContext context)
        {
            _context = context;
            _confi = confi;
        }

        private User AuthenticateUser(UserDto user)
        {
            var query = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            return query;
        }

        private string GenerateToken(User user)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confi["Jwt:Key"]));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(_confi["Jwt.Issuer"], _confi["Jwt.Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: Credentials

                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        [AllowAnonymous]
        [HttpPost("create")]

        public IActionResult Login(UserDto user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);
            if (user_ != null)
            {
                var Token = GenerateToken(user_);
                response = Ok(new { Token = Token });
            }
            return response;
        }
    }
}
