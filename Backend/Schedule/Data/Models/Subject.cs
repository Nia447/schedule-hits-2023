using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Subject
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
