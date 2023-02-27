using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public class Teacher
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"([A-Za-zА-Яа-я]+\s){1,2}[A-Za-zА-Яа-я]+")] // Формат: ФИ или ФИО
        public string FullName { get; set; }
        ICollection<Lesson> Lessons { get; set; }
    }
}
