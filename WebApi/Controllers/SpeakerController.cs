using ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById;
using ConferencePlanner.Application.Speaker.Queries.GetSpeakerList;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferencePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<SpeakerListResponse>>> GetAllSpeakers()
        {
            var result = await Mediator.Send(new GetSpeakerListQuery());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpeakerResponse>> GetSpeaker(int id)
        {
            var result = await Mediator.Send(new GetSpeakerDetailByIdQuery { Id = id  });
            return result;
        }
    }
}