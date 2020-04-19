using MediatR;

namespace ConferencePlanner.Application.Speaker.Queries.GetSpeakerDetailById
{
    public class GetSpeakerDetailByIdQuery : IRequest<SpeakerResponse>    
    {
        public int Id { get; set; }
    }
}
