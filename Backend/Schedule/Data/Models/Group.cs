using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Group
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(16)]
        [MinLength(1)]
        public string Number { get; set; }
        ICollection<Lesson> Lessons { get; set; }
    }
}
