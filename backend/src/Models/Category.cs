namespace backend.src.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; } = null!;
        public Image? Image { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
