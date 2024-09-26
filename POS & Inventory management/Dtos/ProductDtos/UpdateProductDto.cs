using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int Price { get; set; }

        public ProductType ProductType { get; set; }
    }
}
