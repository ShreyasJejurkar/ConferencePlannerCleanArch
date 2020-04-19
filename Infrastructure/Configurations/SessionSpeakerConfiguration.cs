using ConferencePlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SessionSpeakerConfiguration : IEntityTypeConfiguration<SessionSpeaker>
    {
        public void Configure(EntityTypeBuilder<SessionSpeaker> builder)
        {
            builder.HasKey(xa => new { xa.SessionId, xa.SpeakerId});
        }
    }
}
