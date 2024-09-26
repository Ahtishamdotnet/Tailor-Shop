namespace POS___Inventory_management.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public int? BottomLength { get; set; }
        public int? Waist { get; set; }
        public int? BottomLeg { get; set; }
        public int? TopLength {  get; set; }
        public int? Colar { get; set; }
        public int? Chest { get; set; }
        public int? Sleeve { get; set; }
        public int? Shoulder { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }


    }
}
