namespace ProductApi.Model
{
    public class Product
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
