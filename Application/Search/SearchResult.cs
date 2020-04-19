using ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById;

namespace ConferencePlanner.Application.Search
{
    public class SearchResult
    {
        public SearchResultType Type { get; set; }

        public SessionResponse Session { get; set; }

        public SpeakerResponse Speaker { get; set; }
    }
}
