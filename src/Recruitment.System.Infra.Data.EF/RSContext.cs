using Microsoft.EntityFrameworkCore;
using Recruitment.System.Domain.Entity;
using Recruitment.System.Infra.Data.EF.Configurations;
using static Recruitment.System.Infra.Data.EF.Configurations.RecruiterConfiguration;

namespace Recruitment.System.Infra.Data.EF
{
    public class RSContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Candidate> Candidates => Set<Candidate>();
        public DbSet<Recruiter> Recruiters => Set<Recruiter>();
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
        public DbSet<JobVacancy> JobVacancies => Set<JobVacancy>();
        public DbSet<JobApplicationStatusHistory> ApplicationStatusHistories => Set<JobApplicationStatusHistory>();

        public RSContext(DbContextOptions<RSContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new JobVacancyConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new RecruiterConfiguration());
            modelBuilder.ApplyConfiguration(new JobApplicationConfiguration());
        }
    }
}
