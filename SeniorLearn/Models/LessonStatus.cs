namespace SeniorLearn.Models
{
    public class LessonStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Draft, Scheduled, Closed, Complete, Cancelled
        public string Description { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}