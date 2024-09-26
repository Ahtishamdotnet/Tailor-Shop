using POS___Inventory_management.Dtos.SizeDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Mappers
{
    public static class SizeMapper
    {
        public static SizeDto ToSizeDto(this Size sizeModel)
        {
            return new SizeDto
            {
                BottomLength = sizeModel.BottomLength,
                Waist = sizeModel.Waist,
                BottomLeg = sizeModel.BottomLeg,
                TopLength = sizeModel.TopLength,
                Colar = sizeModel.Colar,
                Chest = sizeModel.Chest,
                Sleeve = sizeModel.Sleeve,
                Shoulder = sizeModel.Shoulder,
                Description = sizeModel.Description,
                CustomerId = sizeModel.CustomerId,
            };
        }
        public static Size ToSizeFromCreate(this CreateSizeDto sizeDto, int Id)
        {
            return new Size
            {
                BottomLength = sizeDto.BottomLength,
                Waist = sizeDto.Waist,
                BottomLeg = sizeDto.BottomLeg,
                TopLength = sizeDto.TopLength,
                Colar = sizeDto.Colar,
                Chest = sizeDto.Chest,
                Sleeve = sizeDto.Sleeve,
                Shoulder = sizeDto.Shoulder,
                Description = sizeDto.Description,
                CustomerId = Id,
            };
        }
        public static Size ToSizeFromUpdate(this UpdateSizeDto sizeDto)
        {
            return new Size
            {
                BottomLength = sizeDto.BottomLength,
                Waist = sizeDto.Waist,
                BottomLeg = sizeDto.BottomLeg,
                TopLength = sizeDto.TopLength,
                Colar = sizeDto.Colar,
                Chest = sizeDto.Chest,
                Sleeve = sizeDto.Sleeve,
                Shoulder = sizeDto.Shoulder,
                Description = sizeDto.Description,
            };
        }
    }
}
