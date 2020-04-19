using ConferencePlanner.Application.Attendees.Commands.CreateAttendee;
using ConferencePlanner.Application.Attendees.Commands.RemoveSessionByUsernameAndSessionId;
using ConferencePlanner.Application.Attendees.Queries.GetAttendeeByUsername;
using ConferencePlanner.Application.Attendees.Queries.GetSessionsByUsername;
using ConferencePlanner.Application.Session.Queries.GetAllSessions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferencePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : BaseController
    {
        [HttpGet("{username}")]
        public async Task<ActionResult<AttendeeResponse>> Get(string username)
        {
            var result = await Mediator.Send(new GetAttendeeByUsernameQuery { Username = username });
            return result;
        }

        [HttpGet("{username}/sessions")]
        public async Task<ActionResult<List<SessionResultResponse>>> GetSessions(string username)
        {
            var result = await Mediator.Send(new GetSessionsByUsernameQuery { Username = username });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<AttendeeResponse>> Post(CreateAttendeeCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        public async Task<IActionResult> RemoveSession(string username, int sessionId)
        {
            _ = await Mediator.Send(new RemoveSessionByUsernameAndSessionIdCommand { Username = username, SessionId = sessionId });
            return NoContent();
        }
    }
}