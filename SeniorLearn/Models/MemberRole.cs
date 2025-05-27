namespace SeniorLearn.Models
{
    public class MemberRole
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

        public Member Member { get; set; }
        public Role Role { get; set; }
        public ProfessionalMemberRenewal ProfessionalMemberRenewal { get; set; }
    }
}
