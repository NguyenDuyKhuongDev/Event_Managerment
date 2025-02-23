using System.ComponentModel.DataAnnotations;

namespace EventManagerment.Models
{
    public class Event
    {
        [Key]
        [Required(ErrorMessage = "Event ID is required")]
        public int EventID { get; set; }

        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title cannot be longer than 255 characters")]
        public string? Title { get; set; }

        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [StringLength(255, ErrorMessage = "Location cannot be longer than 255 characters")]
        public string? Location { get; set; }

        public virtual EventCategories? Category { get; set; }

        public virtual ICollection<Attendee>? Attendees { get; set; }
    }
}