using System.ComponentModel.DataAnnotations;

namespace backend.src.Models
{
    public class User : BaseModel
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;
        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public Role Role { get; set; } = Role.Customer;
        public byte[] Password { get; set; } = null!;
        public byte[] Salt { get; set; } = null!;
        public string? Avatar { get; set; }
    }

    public enum Role
    {
        Admin,
        Customer
    }

}

