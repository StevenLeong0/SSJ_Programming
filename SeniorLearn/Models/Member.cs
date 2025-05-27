namespace SeniorLearn.Models
{
    public class Member : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public DateTime MembershipRenewalDate { get; set; }

        public Dashboard Dashboard { get; set; }
        public ICollection<MemberRole> MemberRoles { get; set; } = new List<MemberRole>();
        public ICollection<LearningProgram> LearningPrograms { get; set; } = new List<LearningProgram>();
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public ICollection<PaymentRecord> PaymentRecords { get; set; } = new List<PaymentRecord>();
    }
}