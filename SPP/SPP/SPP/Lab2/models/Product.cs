namespace SPP.Lab2.models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ManufacturesId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int OrderSummaryId { get; set; }
        public OrderSummary OrderSummary { get; set; }
    }
}