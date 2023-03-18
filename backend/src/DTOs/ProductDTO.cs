using backend.src.Models;

namespace backend.src.DTOs
{
    public class ProductBaseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public string? Description { get; set; }
        public ICollection<Image>? Images { get; set; }       
    }

    public class ProductReadDTO : ProductBaseDTO 
    {
        public CategoryReadDTO Category { get; set; }
    }

    public class ProductUpdateDTO : ProductBaseDTO 
    {
        public int CategoryId { get; set; }
    }

    public class ProductCreateDTO : ProductBaseDTO 
    {
        public int CategoryId { get; set; }
    }  
}
