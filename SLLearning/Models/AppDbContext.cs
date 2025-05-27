using Microsoft.EntityFrameworkCore;

namespace SLLearning.Models

{
    public class AppDbContext : DbContext
    {
        public AppDbContext
(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LearningProgram> LearningPrograms { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet <Member> Members { get; set; }

      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasMany(p => p.Lessons)
                .WithMany(p => p.Members)
                .UsingEntity(j => j.ToTable("MemberLessons"));

        }
*/

    }
}


