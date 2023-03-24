using backend.src.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.src.DTOs
{
    public class UserBaseDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [MinLength(3)]
        public string FirstName { get; set; } = null!;
        [MaxLength(100)]
        [MinLength(3)]
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
    }

    public class UserReadDTO : UserBaseDTO
    {
        public Role Role { get; }
    }

    public class UserCreateDTO : UserBaseDTO
    {
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }

    public class UserUpdateDTO : UserBaseDTO
    {
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }

}
