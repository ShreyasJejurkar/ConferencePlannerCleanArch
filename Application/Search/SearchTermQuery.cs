using MediatR;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Application.Search
{
    public class SearchTermQuery : IRequest<List<SearchResult>>
    {
        public string Query { get; set; }
    }
}
