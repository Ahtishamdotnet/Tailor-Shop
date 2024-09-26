namespace POS___Inventory_management.Entities
{
    public class Tailor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhnNo { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}
