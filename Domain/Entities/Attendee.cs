using System.Collections.Generic;

namespace ConferencePlanner.Domain.Entities
{
    public class Attendee
    {
        public int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public string UserName { get; set; }
        public virtual string EmailAddress { get; set; }

        public virtual ICollection<SessionAttendee> SessionsAttendees { get; set; }
    }
}