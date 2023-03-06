namespace Schedule.Data.Models.DTO
{
    public class DailyScheduleDto
    {
        public DateOnly Date { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }
}
