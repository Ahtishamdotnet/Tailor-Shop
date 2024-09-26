namespace POS___Inventory_management.Entities
{
    public enum OrderStatus
    {
        Ordered = 0,
        InProgress = 1,
        Stitched = 2,
        Delivered = 3,
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int TotalPrice { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public virtual Tailor Tailor { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }  
    }
}
