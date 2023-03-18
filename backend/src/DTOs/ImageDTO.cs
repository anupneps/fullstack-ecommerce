namespace backend.src.DTOs
{
    public class ImageBaseDTO
    {
        public string Url { get; set; }
    }

    public class ImageReadDTO : ImageBaseDTO { }

    public class ImageUpdateDTO : ImageBaseDTO 
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }

    public class ImageCreateDTO : ImageBaseDTO { }

}
