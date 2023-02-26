using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models
{
    public enum TypeLesson
    {
        Seminar,
        Lecture,
        Practice,
        Laboratory,
        Exam,
        Consultation,
        Credit,
        Test
    }
    public static class TypeLessonClass
    {
        private static List<TypeLesson> array = new List<TypeLesson>() { TypeLesson.Seminar, TypeLesson.Lecture, TypeLesson.Practice, TypeLesson.Laboratory, TypeLesson.Exam, TypeLesson.Consultation, TypeLesson.Credit, TypeLesson.Test };

        public static TypeLesson GetTypeLesson(int number)
        {
            return array[number];
        }
    }
}
