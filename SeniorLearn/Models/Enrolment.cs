namespace SeniorLearn.Models
{
    public class Enrolment
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int LessonId { get; set; }

        public Member Member { get; set; }
        public Lesson Lesson { get; set; }
    }
}