using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public enum TimeSlot
    {
        [Display(Name = "8:45-10:20")]
        FirstLesson,
        [Display(Name = "10:35-12:10")]
        SecondLesson,
        [Display(Name = "12:25-14:00")]
        ThirdLesson,
        [Display(Name = "14:45-16:20")]
        FourthLesson,
        [Display(Name = "16:35-18:10")]
        FifthLesson,
        [Display(Name = "18:25-20:00")]
        SixthLesson,
        [Display(Name = "20:15-21:50")]
        SeventhLesson,
    }
    public static class TimeSlotClass
    {
        private static List<TimeSlot> array = new List<TimeSlot>() { TimeSlot.FirstLesson, TimeSlot.SecondLesson, TimeSlot.ThirdLesson, TimeSlot.FourthLesson, TimeSlot.FifthLesson, TimeSlot.SixthLesson, TimeSlot.SeventhLesson };

        public static TimeSlot GetTimeSlot(int number)
        {
            return array[number - 1];
        }
    }
}
