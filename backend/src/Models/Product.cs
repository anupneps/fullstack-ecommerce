namespace backend.src.Models
{
    public class Product : BaseModel
    {
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public string? Description { get; set; }
        public ICollection<Image>? Images { get; set; }

        public Category Category { get; set; } = null!;
    }
}
