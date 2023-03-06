using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Lesson
    {
        [Required]
        public Guid Id { get; set; }

        public NumberLesson? NumberLesson { get; set; }

        public DayOfTheWeek? Day { get; set; }

        public TypeLesson? Type { get; set; }

        [Range(typeof(DateTime), "2022-09-01T00:01:01.001Z", "2025-01-01T00:01:01.000Z",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? StartPeriodDate { get; set; }

        [Range(typeof(DateTime), "2022-09-01T00:01:01.001Z", "2025-01-01T00:01:01.000Z",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? EndPeriodDate { get; set; }

        public Guid? ChangeIdLesson { get; set; }

        public Group? Group { get; set; }

        public Subject? Subject { get; set; }

        public Teacher? Teacher { get; set; }

        public Audience? Audience { get; set; }
    }
}
