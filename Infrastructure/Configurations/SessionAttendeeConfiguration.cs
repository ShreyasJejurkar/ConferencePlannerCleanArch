using ConferencePlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SessionAttendeeConfiguration : IEntityTypeConfiguration<SessionAttendee>
    {
        public void Configure(EntityTypeBuilder<SessionAttendee> builder)
        {
            builder.HasKey(xa => new { xa.SessionId, xa.AttendeeId });
        }
    }
}
