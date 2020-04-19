using ConferencePlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.Id)
                    .HasColumnName("SessionId");

            builder.Property(x => x.Title)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(x => x.Abstract)
                    .HasMaxLength(4000);

            builder.HasOne(x => x.Track);
        }
    }
}
