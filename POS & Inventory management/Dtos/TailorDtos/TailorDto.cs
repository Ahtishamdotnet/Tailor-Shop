using POS___Inventory_management.Entities;

namespace POS___Inventory_management.Dtos.TailorDtos
{
    public class TailorDto
    {
        public string Name { get; set; }
        public int PhnNo { get; set; }
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
