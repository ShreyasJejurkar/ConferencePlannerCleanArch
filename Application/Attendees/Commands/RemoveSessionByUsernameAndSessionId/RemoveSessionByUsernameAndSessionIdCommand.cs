using AutoMapper;
using MediatR;
using System;
using System.Text;

namespace ConferencePlanner.Application.Attendees.Commands.RemoveSessionByUsernameAndSessionId
{
    public class RemoveSessionByUsernameAndSessionIdCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public int SessionId { get; set; }
    }
}
