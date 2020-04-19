using MediatR;
using System.Collections.Generic;

namespace ConferencePlanner.Application.Speaker.Queries.GetSpeakerList
{
    public class GetSpeakerListQuery : IRequest<List<SpeakerListResponse>>
    {
    }
}
