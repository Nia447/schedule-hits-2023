using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Audience
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(3)]
        public string Number { get; set; }
    }
}
