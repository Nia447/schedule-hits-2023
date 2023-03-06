namespace Schedule.Data.Models.DTO
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public NumberLesson NumberLesson { get; set; }
        public DayOfTheWeek Day { get; set; }
        public TypeLesson Type { get; set; }
        public DateTime StartPeriodDate { get; set; }
        public DateTime EndPeriodDate { get; set; }
        public SubjectDto Subject { get; set; }
        public GroupDto Group { get; set; }
        public TeacherDto Teacher { get; set; }
        public AudienceDto Audience { get; set; }
    }
}
