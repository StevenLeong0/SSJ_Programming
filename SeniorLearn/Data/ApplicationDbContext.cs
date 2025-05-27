using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeniorLearn.Models;

namespace SeniorLearn.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for SeniorLearn entities
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<ProfessionalMemberRenewal> ProfessionalMemberRenewals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LearningProgram> LearningPrograms { get; set; }
        public DbSet<LessonStatus> LessonStatuses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<ServiceItemHistory> ServiceItemHistories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }
        public DbSet<EFTPayment> EFTPayments { get; set; }
        public DbSet<CreditCardPayment> CreditCardPayments { get; set; }
        public DbSet<ChequePayment> ChequePayments { get; set; }
        public DbSet<BankTransferPayment> BankTransferPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureRelationships(modelBuilder);
            SeedInitialData(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Configure User TPT inheritance strategy
            modelBuilder.Entity<User>().UseTptMappingStrategy();

            // Configure Administrator relationship to User with shared key
            modelBuilder.Entity<Administrator>()
                .ToTable("Administrators")
                .HasOne<User>().WithOne()
                .HasForeignKey<Administrator>(a => a.Id);

            // Configure Member relationship to User with shared key
            modelBuilder.Entity<Member>()
                .ToTable("Members")
                .HasOne<User>().WithOne()
                .HasForeignKey<Member>(m => m.Id);

            // Member and MemberRole: One-to-Many relationship
            modelBuilder.Entity<MemberRole>()
                .HasOne(mr => mr.Member)
                .WithMany(m => m.MemberRoles)
                .HasForeignKey(mr => mr.MemberId);

            // Role and MemberRole: One-to-Many relationship
            modelBuilder.Entity<MemberRole>()
                .HasOne(mr => mr.Role)
                .WithMany(r => r.MemberRoles)
                .HasForeignKey(mr => mr.RoleId);

            // Role Configuration
            modelBuilder.Entity<Role>()
                // Rename to avoid conflict with AspNetRoles
                .ToTable("MembershipRoles");

            // MemberRole and ProfessionalMemberRenewal: One-to-One relationship
            modelBuilder.Entity<ProfessionalMemberRenewal>()
                .HasKey(pmr => pmr.MemberRoleId);

            modelBuilder.Entity<ProfessionalMemberRenewal>()
                .HasOne(pmr => pmr.MemberRole)
                .WithOne(mr => mr.ProfessionalMemberRenewal)
                .HasForeignKey<ProfessionalMemberRenewal>(pmr => pmr.MemberRoleId);

            // Category and LearningProgram: One-to-Many relationship
            modelBuilder.Entity<LearningProgram>()
                .HasOne(p => p.Category)
                .WithMany(c => c.LearningPrograms)
                .HasForeignKey(p => p.CategoryId);

            // Member and LearningProgram: One-to-Many relationship
            modelBuilder.Entity<LearningProgram>()
                .HasOne(p => p.Member)
                .WithMany(m => m.LearningPrograms)
                .HasForeignKey(p => p.MemberId);

            // LearningProgram and Lesson: One-to-Many relationship
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.LearningProgram)
                .WithMany(p => p.Lessons)
                .HasForeignKey(l => l.ProgramId);

            // LessonStatus and Lesson: One-to-Many relationship
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Status)
                .WithMany(ls => ls.Lessons)
                .HasForeignKey(l => l.StatusId);

            // Member and Enrolment: One-to-Many relationship
            modelBuilder.Entity<Enrolment>()
                .HasOne(e => e.Member)
                .WithMany(m => m.Enrolments)
                .HasForeignKey(e => e.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lesson and Enrolment: One-to-Many relationship
            modelBuilder.Entity<Enrolment>()
                .HasOne(e => e.Lesson)
                .WithMany(l => l.Enrolments)
                .HasForeignKey(e => e.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Member and Dashboard: One-to-One relationship
            modelBuilder.Entity<Dashboard>()
                .HasKey(d => d.MemberId);

            modelBuilder.Entity<Dashboard>()
                .HasOne(d => d.Member)
                .WithOne(m => m.Dashboard)
                .HasForeignKey<Dashboard>(d => d.MemberId);

            // Configure PaymentRecord TPT inheritance strategy
            modelBuilder.Entity<PaymentRecord>().UseTptMappingStrategy();

            // Member and PaymentRecord: One-to-Many relationship
            modelBuilder.Entity<PaymentRecord>()
                .HasOne(p => p.Member)
                .WithMany(m => m.PaymentRecords)
                .HasForeignKey(p => p.MemberId);

            // ServiceItemHistory and PaymentRecord: One-to-Many relationship
            modelBuilder.Entity<PaymentRecord>()
                .HasOne(p => p.ServiceItemHistory)
                .WithMany(s => s.PaymentRecords)
                .HasForeignKey(p => p.ServiceItemHistoryId);

            // PaymentMethod and PaymentRecord: One-to-Many relationship
            modelBuilder.Entity<PaymentRecord>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.PaymentRecords)
                .HasForeignKey(p => p.PaymentMethodId);
        }

        private void SeedInitialData(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Standard" },
                new Role { Id = 2, RoleName = "Professional" },
                new Role { Id = 3, RoleName = "Honorary" }
            );
        }
    }
}
