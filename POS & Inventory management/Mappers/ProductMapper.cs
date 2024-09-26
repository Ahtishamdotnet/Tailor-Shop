using POS___Inventory_management.Dtos.ProductDtos;
using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product entity)
        {
            return new ProductDto
            {
                Price = entity.Price,
                ProductType = entity.ProductType,
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductDto productDto)
        {
            return new Product
            { 
                Price = productDto.Price,
                ProductType = productDto.ProductType,
            };
        }
    }
}
