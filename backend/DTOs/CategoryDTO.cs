using backend.DTOs;

namespace backend.Models
{
    public class CategoryDTO : BaseDTO<Category>
    {
        public string Name { get; set; } = null!;
        public Image? Image { get; set; }

        public override void UpdateModel(Category model)
        {
            model.Name = Name;
            model.Image = Image;
        }
        
    }
}
