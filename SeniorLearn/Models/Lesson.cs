namespace SeniorLearn.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int StatusId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string DeliveryMode { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public LearningProgram LearningProgram { get; set; }
        public LessonStatus Status { get; set; }
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}