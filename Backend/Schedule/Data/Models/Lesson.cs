using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Lesson
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSlot TimeSlot { get; set; }

        [Required]
        public Group Group { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [Required]
        public Teacher Teacher { get; set; }
    }
}
