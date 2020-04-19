using ConferencePlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferencePlanner.Infrastructure.Configurations
{
    public class AttendeeConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.Property(x => x.Id)
                    .HasColumnName("AttendeeId");

            builder.HasIndex(x => x.UserName)
                    .IsUnique();

            builder.Property(x => x.FirstName)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(x => x.LastName)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(x => x.UserName)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(x => x.EmailAddress)
                    .HasMaxLength(256);
        }
    }
}
