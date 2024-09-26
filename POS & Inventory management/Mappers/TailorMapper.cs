using POS___Inventory_management.Dtos.TailorDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Mappers
{
    public static class TailorMapper
    {
        public static TailorDto ToTailorDto(this Tailor entity)
        {
            return new TailorDto
            {
                Name = entity.Name,
                PhnNo = entity.PhnNo,
                Address = entity.Address,
            };
        }

        public static Tailor ToTailorFromCreateDto(this CreateTailorDto tailorDto)
        {
            return new Tailor
            {
                Name = tailorDto.Name,
                PhnNo = tailorDto.PhnNo,
                Address = tailorDto.Address,
            };
        }
    }
}
