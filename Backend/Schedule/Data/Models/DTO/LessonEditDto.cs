namespace Schedule.Data.Models.DTO
{
    public class LessonEditDto
    {
        public Guid Id { get; set; }
        public Guid IdSubject { get; set; }
        public Guid IdGroup { get; set; }
        public Guid IdTeacher { get; set; }
        public Guid IdAudience { get; set; }
        public TimeSlotDto TimeSlot { get; set; }
    }
}
