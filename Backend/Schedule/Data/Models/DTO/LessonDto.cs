namespace Schedule.Data.Models.DTO
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public SubjectDto Subject { get; set; }
        public GroupDto Group { get; set; }
        public TeacherDto Teacher { get; set; }
        public AudienceDto Audience { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
    }
}
