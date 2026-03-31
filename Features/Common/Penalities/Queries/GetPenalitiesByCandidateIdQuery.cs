using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Penalities.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Penalities;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Penalities.Queries
{
    public record GetPenalitiesByCandidateIdQuery(string? CandidateId, DateTime? From, DateTime? To,
        int pageIndex = 1, int pageSize = 100):IRequestBase<PagingViewModel<GetPenalitiesByCandidateIdDTO>>;
    public class GetPenalitiesByCandidateIdQueryHandler : RequestHandlerBase<Penality, GetPenalitiesByCandidateIdQuery, PagingViewModel<GetPenalitiesByCandidateIdDTO>>
    {
        public GetPenalitiesByCandidateIdQueryHandler(RequestHandlerBaseParameters<Penality> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetPenalitiesByCandidateIdDTO>>> Handle(GetPenalitiesByCandidateIdQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Penality>(true);
            var candidateId = !string.IsNullOrWhiteSpace(request.CandidateId)
                   ? request.CandidateId
                   : _userState.UserID;

            predicate = predicate
                .And(p => p.CandidateId == candidateId)
                .And(p => !request.From.HasValue || p.CreatedDate >= request.From)
                .And(p => !request.To.HasValue || p.CreatedDate <= request.To);

            var query = await _repository
                .Get(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .Map<GetPenalitiesByCandidateIdDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetPenalitiesByCandidateIdDTO>>.Success(query);
        }
    }
}
