using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruitment.System.Domain.Entity;

namespace Recruitment.System.Infra.Data.EF.Configurations
{
    internal class JobVacancyConfiguration
        : IEntityTypeConfiguration<JobVacancy>
    {
        public void Configure(EntityTypeBuilder<JobVacancy> builder)
        {
            builder.ToTable("JobVacancies");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.IsDeleted)
                   .IsRequired();
          
            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(n => n.Title)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(n => n.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.HasOne<Recruiter>()
                   .WithMany()
                   .HasForeignKey(j => j.RecruiterId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }

}
