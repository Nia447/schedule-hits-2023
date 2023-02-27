using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Subject
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(3)]
        public string Name { get; set; }
        ICollection<Lesson> Lessons { get; set; }
    }
}
