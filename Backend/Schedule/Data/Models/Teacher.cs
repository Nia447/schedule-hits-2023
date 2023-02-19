using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Teacher
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
