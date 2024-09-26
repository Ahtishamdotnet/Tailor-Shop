using POS___Inventory_management.Dtos.UserDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromCreate(this CreateUserDto userRegistrationDto)
        {
            return new User
            {
                UserName = userRegistrationDto.UserName,
                Password = userRegistrationDto.Password,
            };
        }
    }
}
