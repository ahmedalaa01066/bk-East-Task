using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetCandidateDataQuery(string CandidateId) :IRequestBase<GetCandidateDataDTO>;
    public class GetCandidateDataQueryHandler : RequestHandlerBase<Candidate, GetCandidateDataQuery, GetCandidateDataDTO>
    {
        public GetCandidateDataQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetCandidateDataDTO>> Handle(GetCandidateDataQuery request, CancellationToken cancellationToken)
        {
            var Candidate =  _repository.Get(c=>c.ID== request.CandidateId)
                .Include(c => c.Job)
                .Include(c => c.User)
                .FirstOrDefault()
                .MapOne<GetCandidateDataDTO>();
            if (Candidate == null)
            {
                return RequestResult<GetCandidateDataDTO>.Failure(ErrorCode.NotFound);
            }
            var candidateImageResult = await _mediator.Send(new GetMediaForAnySourceQuery(request.CandidateId, SourceType.CandidateImage));


            var candidateWithMedia = Candidate with
            {
                CandidateImage = candidateImageResult.IsSuccess ? candidateImageResult.Data : string.Empty
            };

            return RequestResult<GetCandidateDataDTO>.Success(candidateWithMedia);
        }
    }
}
