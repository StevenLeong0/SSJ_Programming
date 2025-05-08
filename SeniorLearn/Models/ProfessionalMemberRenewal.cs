namespace SeniorLearn.Models
{
    public class ProfessionalMemberRenewal
    {
        public int MemberRoleId { get; set; }   // Primary key and Foreign key
        public DateTime ProfessionalRenewalDate { get; set; }

        public MemberRole MemberRole { get; set; }
    }
}
