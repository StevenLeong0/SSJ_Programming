namespace SLLearning.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Enrolment> Enrollments { get; set; } = new List<Enrolment>();

      
    }
}
