using backend.src.Models;

namespace backend.src.DTOs
{
    public class CategoryBaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Image? Image { get; set; }

    }

    public class CategoryReadDTO : CategoryBaseDTO { }

    public class CategoryUpdateDTO : CategoryBaseDTO
    {

    }

    public class CategoryCreateDTO : CategoryBaseDTO { }

}
