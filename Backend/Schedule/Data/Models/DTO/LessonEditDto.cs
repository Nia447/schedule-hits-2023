namespace Schedule.Data.Models.DTO
{
    public class LessonEditDto
    {
        public Guid Id { get; set; }
        public Guid IdSubject { get; set; }
        public Guid IdGroup { get; set; }
        public Guid IdTeacher { get; set; }
        public Guid IdAudience { get; set; }
        public NumberLesson NumberLesson { get; set; }
        public DayOfTheWeek Day { get; set; }
        public TypeLesson Type { get; set; }
        public DateTime StartPeriodDate { get; set; }
        public DateTime? EndPeriodDate { get; set; }
        public bool DeletePrevLesson { get; set; }
    }
}
