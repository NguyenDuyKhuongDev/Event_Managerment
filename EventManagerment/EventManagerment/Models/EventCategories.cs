using System.ComponentModel.DataAnnotations;

namespace EventManagerment.Models
{
    public class EventCategories
    {
        [Key]
        [Required(ErrorMessage = "Category id is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(255, ErrorMessage = "Category name must be less than 255 characters")]
        public string? CategoryName { get; set; }

        public virtual ICollection<Event>? Events { get; set; }
    }
}