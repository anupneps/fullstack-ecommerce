using backend.src.DTOs;

namespace backend.src.Models
{
    public class Product : BaseModel
    {
        #region Properties
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public string? Description { get; set; }
        public ICollection<Image>? Images { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        #endregion

        #region Update

        public void Update(ProductUpdateDTO request)
        {

        }

        #endregion

    }
}
