using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Lesson
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(typeof(DateTime), "2022-09-01T00:01:01.001Z", "2025-01-01T00:01:01.000Z",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
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
