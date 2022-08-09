namespace CoreLayer.EntityModels
{
    public class Chart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
