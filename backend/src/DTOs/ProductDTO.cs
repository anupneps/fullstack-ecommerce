using backend.src.Models;

namespace backend.src.DTOs
{
    public class ProductBaseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public string? Description { get; set; }
        public ICollection<Image>? Images { get; set; }
        public Category Category { get; set; } = null!;
        //public Guid CategoryId { get; set; }
    }

    public class ProductReadDTO : ProductBaseDTO { }

    public class ProductUpdateDTO : ProductBaseDTO { }

    public class ProductCreateDTO : ProductBaseDTO { }  
}
