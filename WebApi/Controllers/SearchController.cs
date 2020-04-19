using System.Collections.Generic;
using System.Threading.Tasks;
using ConferencePlanner.Application.Search;
using Microsoft.AspNetCore.Mvc;

namespace ConferencePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<List<SearchResult>>> Search(string query)
        {
            var result = await Mediator.Send(new SearchTermQuery() { Query = query  });
            return result;
        }
    }
}
