﻿namespace SeniorLearn.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<MemberRole> MemberRoles { get; set; } = new List<MemberRole>();
    }
}
