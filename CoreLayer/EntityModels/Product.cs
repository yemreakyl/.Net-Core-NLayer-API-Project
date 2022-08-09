namespace CoreLayer.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        public int ChartId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
