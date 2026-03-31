using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateKPIs.DTOs;
using EasyTask.Features.Common.CandidateKPIs.Queries;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetAllCandidatesWithKPIsQuery(string? SearchText,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllCandidatesWithKPIsDTO>>;
    public class GetAllCandidatesWithKPIsQueryHandler : RequestHandlerBase<Candidate, GetAllCandidatesWithKPIsQuery, PagingViewModel<GetAllCandidatesWithKPIsDTO>>
    {
        public GetAllCandidatesWithKPIsQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCandidatesWithKPIsDTO>>> Handle(GetAllCandidatesWithKPIsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Candidate>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.SearchText) ||
                          c.FirstName.Contains(request.SearchText) ||
                          c.LastName.Contains(request.SearchText));

            var query = _repository
                .Get(predicate)
                .Include(c => c.Position);

            var model = await query
                .Map<GetAllCandidatesWithKPIsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            foreach (var candidate in model.Items)
            {
                var mediaResult = await _mediator.Send(new GetMediaForAnySourceQuery(candidate.ID, SourceType.CandidateImage));
                candidate.Path = mediaResult.Data;
                var kpiResult = await _mediator.Send(new GetKPIsByCandidateIdQuery(candidate.ID));
                candidate.CandidateKPIs = kpiResult.Data ?? new GetKPIsByCandidateIdDTO
                {
                    KPIsName = new List<string>(),
                    UpdatedDate = null
                };
            }

            return RequestResult<PagingViewModel<GetAllCandidatesWithKPIsDTO>>.Success(model);
        }
    }
}
