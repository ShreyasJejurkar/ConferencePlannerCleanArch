using System.Collections.Generic;
using System.Threading.Tasks;
using ConferencePlanner.Application.Session.Commands.CreateSession;
using ConferencePlanner.Application.Session.Commands.DeleteSession;
using ConferencePlanner.Application.Session.Commands.UpdateSession;
using ConferencePlanner.Application.Session.Queries.GetAllSessions;
using ConferencePlanner.Application.Session.Queries.GetSessionById;
using Microsoft.AspNetCore.Mvc;
using SessionResultResponse = ConferencePlanner.Application.Session.Queries.GetSessionById.SessionResultResponse;

namespace ConferencePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : BaseController
    {
        public async Task<ActionResult<List<Application.Session.Queries.GetAllSessions.SessionResultResponse>>> Get()
        {
            var result = await Mediator.Send(new GetAllSessionsQuery());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionResultResponse>> GetSessionById(int id)
        {
            var result = await Mediator.Send(new GetSessionByIdQuery() {  Id = id });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<SessionResultResponse>> CreateSession(CreateSessionCommand command )
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, UpdateSessionCommand updateCommand)
        {
            updateCommand.Id = id;
            _ = await Mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<SessionResultResponse>> Delete(DeleteSessionCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}