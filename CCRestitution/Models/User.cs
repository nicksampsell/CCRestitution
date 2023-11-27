using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CCRestitution.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        [DisplayName("Network Username")]
        [Required]
        public string? Identity { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }

    public enum UserRole
    {
        User,
        Supervisor,
        Administrator,
        Developer
    }
}
