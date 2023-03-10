using backend.DTOs;

namespace backend.Models
{
    public class ImageDTO : BaseDTO<Image>
    {
        public string? Title { get; set; }

        public override void UpdateModel(Image model)
        {
            model.Title = Title;
            model.CreatedAt = DateTime.Now;
            model.LastUpdatedAt = DateTime.Now;
        }
    }
}
