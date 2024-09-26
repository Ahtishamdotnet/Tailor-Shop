namespace POS___Inventory_management.Entities
{
    public enum ProductType
    {
        Shirt = 1,
        Pant = 2,
        PantShirt = 3,
        Shalwaar = 4,
        Kameez = 5,
        ShalwaarKameez = 6,
    }

    public class Product
    {
        public int Id { get; set; }
        public int Price { get; set; }
        
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
