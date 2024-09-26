using System.Numerics;

namespace POS___Inventory_management.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }


        public virtual Size Sizes { get; set; }
    }
}
