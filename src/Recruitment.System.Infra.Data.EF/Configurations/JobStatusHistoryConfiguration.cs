using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruitment.System.Domain.Entity;

namespace Recruitment.System.Infra.Data.EF.Configurations
{
    internal class JobStatusHistoryConfiguration
      : IEntityTypeConfiguration<JobApplicationStatusHistory>
    {
        public void Configure(EntityTypeBuilder<JobApplicationStatusHistory> builder)
        {
            builder.ToTable("JobApplicationStatusHistories");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(n => n.ChangedAt)
                   .IsRequired();

            builder.Property(n => n.ChangedBy)
                   .IsRequired();

            builder.Property(n => n.Note)
                   .HasMaxLength(250);

            builder.Property(n => n.Status)
                   .HasConversion<string>()
                   .IsRequired();


            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }

}
