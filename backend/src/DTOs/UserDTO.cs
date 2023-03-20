using backend.src.Models;

namespace backend.src.DTOs
{
    public class UserBaseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class UserReadDTO : UserBaseDTO { }

    public class UserCreateDTO : UserBaseDTO
    {
        public string Password { get; set; } = null!;
        //public Role Role { get; set; }
    }

    public class UserUpdateDTO : UserBaseDTO
    {
        public string Password { get; set; } = null!;
    }

}
