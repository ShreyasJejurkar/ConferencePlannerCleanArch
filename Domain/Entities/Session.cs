using System;
using System.Collections.Generic;

namespace ConferencePlanner.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual string Abstract { get; set; }
        public virtual DateTimeOffset? StartTime { get; set; }
        public virtual DateTimeOffset? EndTime { get; set; }
        public TimeSpan Duration => EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ?? TimeSpan.Zero;

        public Track Track { get; set; }
        public int? TrackId { get; set; }

        public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; }
        public virtual ICollection<SessionAttendee> SessionAttendees { get; set; }
    }
}
