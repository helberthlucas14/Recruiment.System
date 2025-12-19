using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruitment.System.Domain.Entity;

namespace Recruitment.System.Infra.Data.EF.Configurations
{
    internal class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            
            builder.Property(u => u.IsDeleted)
                   .IsRequired();
           
            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(n => n.ExternalId)
                   .IsRequired();

            builder.Property(n => n.Email)
                   .IsRequired();

            builder.Property(n => n.Role)
                   .HasConversion<string>()
                   .IsRequired();

            builder.HasIndex(u => u.ExternalId).IsUnique();

            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }

}
