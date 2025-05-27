using System.Reflection.Metadata.Ecma335;

namespace SLLearning.Models
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

        //public Member Member { get; set; }
        public Category Category { get; set; }
        //public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

        public static List<LearningProgram> Programs => new List<LearningProgram>
    {
        new LearningProgram
        {
            Id = 1,
            MemberId = 1,
            CategoryId = 1,
            ProgramCode = "1",
            Title = "1",
            Description = "1",
            StartDate = new DateTime(2025, 1, 25),
            EndDate = new DateTime(2025, 2, 25),
            IsCourse = false
        },
        new LearningProgram
        {
            Id = 2,
            MemberId = 2,
            CategoryId = 2,
            ProgramCode = "2",
            Title = "2",
            Description = "2",
            StartDate = new DateTime(2026, 1, 26),
            EndDate = new DateTime(2026, 2, 26)
        }
    };

        public static List <LearningProgram> GetProgramDetails(int id)
        {


            return Programs.Where(p => p.Id == id).ToList();
        }

        public static List <LearningProgram> GetProgramByMember (int MemberId)
        {

            return Programs.Where (p => p.MemberId == MemberId).ToList();
        }

        public static List <LearningProgram> GetProgramByCategory (int CategoryId)
        {
            return Programs.Where (p=>p.CategoryId == CategoryId).ToList();
        }
    }
}