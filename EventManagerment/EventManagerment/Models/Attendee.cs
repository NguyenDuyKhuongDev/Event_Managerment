using System.ComponentModel.DataAnnotations;

namespace EventManagerment.Models
{
    public class Attendee
    {
        [Key]
        [Required(ErrorMessage = "AttendeeId is required")]
        public int AttendeeId { get; set; }

        public int UserId { get; set; }
        public int EventId { get; set; }

        [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
        public string? Name { get; set; }

        [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters")]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime RegistationTime { get; set; } = DateTime.Now;

        public virtual User? User { get; set; }
        public virtual Event? Event { get; set; }
    }
}