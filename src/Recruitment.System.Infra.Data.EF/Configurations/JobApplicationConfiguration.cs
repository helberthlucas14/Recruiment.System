using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruitment.System.Domain.Entity;

namespace Recruitment.System.Infra.Data.EF.Configurations
{
    internal class JobApplicationConfiguration
       : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplications");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.IsDeleted)
                   .IsRequired();

            builder.Property(u => u.CurrentStatus)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.HasOne<Candidate>()
                   .WithMany()
                   .HasForeignKey(a => a.CandidateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<JobVacancy>()
                   .WithMany()
                   .HasForeignKey(a => a.JobVacancyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsMany(a => a.Histories, h =>
            {
                h.WithOwner().HasForeignKey("JobApplicationId");
                h.Property<Guid>("Id");
                h.HasKey("Id");
                h.Property(x => x.Status).IsRequired();
                h.Property(x => x.ChangedAt).IsRequired();
                h.Property(x => x.ChangedBy).IsRequired();
                h.Property(x => x.Note);
                h.ToTable("JobApplicationStatusHistories");
            });

            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
