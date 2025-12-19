using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruitment.System.Domain.Entity;

namespace Recruitment.System.Infra.Data.EF.Configurations
{

    internal partial class RecruiterConfiguration
    {
        internal class CandidateConfiguration
        : IEntityTypeConfiguration<Candidate>
        {
            public void Configure(EntityTypeBuilder<Candidate> builder)
            {
                builder.ToTable("Candidates");
                builder.HasKey(x => x.Id);

                builder.Property(r => r.UserId).IsRequired();
                builder.Property(r => r.IsDeleted).IsRequired();
                builder.Property(r => r.CreatedAt).IsRequired();

                builder.HasOne<User>()
                       .WithMany()
                       .HasForeignKey(r => r.UserId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasQueryFilter(u => !u.IsDeleted);
            }
        }
    }
}
