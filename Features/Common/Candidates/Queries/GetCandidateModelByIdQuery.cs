using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Candidates;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetCandidateModelByIdQuery(string ID):IRequestBase<Candidate>;
    public class GetCandidateModelByIdQueryHandler : RequestHandlerBase<Candidate, GetCandidateModelByIdQuery, Candidate>
    {
        public GetCandidateModelByIdQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<Candidate>> Handle(GetCandidateModelByIdQuery request, CancellationToken cancellationToken)
        {
            var Candidate =  _repository.Get(c=>c.ID== request.ID).FirstOrDefault();

            if (Candidate == null)
            {
                return RequestResult<Candidate>.Failure(ErrorCode.NotFound);
            }

            return RequestResult<Candidate>.Success(Candidate);
        }
    }
}
