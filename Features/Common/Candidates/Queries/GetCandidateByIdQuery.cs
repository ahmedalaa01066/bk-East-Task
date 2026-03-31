using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Documents.Queries;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetCandidateByIdQuery(string ID):IRequestBase<GetCandidateByIdDTO>;
    public class GetCandidateByIdQueryHandler : RequestHandlerBase<Candidate, GetCandidateByIdQuery, GetCandidateByIdDTO>
    {
        public GetCandidateByIdQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetCandidateByIdDTO>> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var Candidate =  _repository.Get(c=>c.ID== request.ID)
                .Include(c=>c.Level)
                .Include(c=>c.Job)
                .Include(c=>c.User)
                .FirstOrDefault()
                .MapOne<GetCandidateByIdDTO>();
            if (Candidate == null)
            {
                return RequestResult<GetCandidateByIdDTO>.Failure(ErrorCode.NotFound);
            }
            var candidateImageResult = await _mediator.Send(new GetMediaForAnySourceQuery(request.ID, SourceType.CandidateImage));

            var candidatePathsResult = await _mediator.Send(new GetAllMediaForAnySourceQuery(request.ID, SourceType.CandidateData));
            var document = await _mediator.Send(new GetDocumentIdBySourceIdAndTypeQuery(request.ID, DocumentType.Candidate));

            var candidateWithMedia = Candidate with
            {
                CandidateImage = candidateImageResult.IsSuccess ? candidateImageResult.Data : string.Empty,
                Paths = candidatePathsResult.IsSuccess
                    ? candidatePathsResult.Data.Select(m => m.Path).ToList()
                    : new List<string>(),
                DocumentId=document.Data.ID,
                DocumentPath=document.Data.Path

            };

            return RequestResult<GetCandidateByIdDTO>.Success(candidateWithMedia);
        }
    }
}
