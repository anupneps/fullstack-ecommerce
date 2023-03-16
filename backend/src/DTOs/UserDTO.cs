namespace backend.src.DTOs
{
    public class UserBaseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class UserReadDTO : UserBaseDTO { }

    public class UserCreateDTO : UserBaseDTO
    {
        public string Password { get; set; }
    }

    public class UserUpdateDTO : UserBaseDTO
    {
        public string Password { get; set; }
    }

}
