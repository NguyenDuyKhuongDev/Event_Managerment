using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagerment.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(255, ErrorMessage = "Username must be between 3 and 255 characters", MinimumLength = 3)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password must be between 3 and 255 characters", MinimumLength = 3)]
        public string? Password { get; set; }

        [StringLength(255, ErrorMessage = "Full name must be between 3 and 255 characters", MinimumLength = 3)]
        public string? FullName { get; set; }

        [EmailAddress]
        [StringLength(255, ErrorMessage = "Email must be between 3 and 255 characters", MinimumLength = 3)]
        public string? Email { get; set; }

        [StringLength(255, ErrorMessage = "Role must be between 3 and 255 characters", MinimumLength = 3)]
        public string? Role { get; set; }

        public ICollection<Attendee>? Attendees { get; set; }
    }
}