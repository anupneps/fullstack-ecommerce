using backend.DTOs;

namespace backend.Models
{
    public class ProductDTO : BaseDTO<Product>
    {
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Image>? Images { get; set; }

        public override void UpdateModel(Product model)
        {
            model.Title = Title;
            model.Price = Price;
            model.Description = Description;
            model.Category = Category;
            model.Images = Images;
        }
    }
}
