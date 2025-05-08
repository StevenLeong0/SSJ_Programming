namespace SeniorLearn.Models
{
    public class LearningProgram
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CategoryId { get; set; }
        public string ProgramCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCourse { get; set; }  // true = cohesive course, false = standalone lesson

        public Member Member { get; set; }
        public Category Category { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}