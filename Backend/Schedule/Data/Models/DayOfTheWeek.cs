using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public enum DayOfTheWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public static class DayOfTheWeekClass
    {
        private static List<DayOfTheWeek> array = new List<DayOfTheWeek>() { DayOfTheWeek.Monday, DayOfTheWeek.Tuesday, DayOfTheWeek.Wednesday, DayOfTheWeek.Thursday, DayOfTheWeek.Friday, DayOfTheWeek.Saturday, DayOfTheWeek.Sunday };

        public static DayOfTheWeek GetDayOfTheWeek(int number)
        {
            return array[number];
        }
    }
}
