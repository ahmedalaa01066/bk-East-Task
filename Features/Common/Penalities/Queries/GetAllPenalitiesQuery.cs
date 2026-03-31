using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Penalities.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Penalities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Penalities.Queries
{
    public record GetAllPenalitiesQuery
        (string? CandidateId, DateTime? From, DateTime? To, int pageIndex = 1, int pageSize = 100)
        : IRequestBase<PagingViewModel<GetAllPenalitiesDTO>>;
    public class GetAllPenalitiesQueryHandler : RequestHandlerBase<Penality, GetAllPenalitiesQuery, PagingViewModel<GetAllPenalitiesDTO>>
    {
        public GetAllPenalitiesQueryHandler(RequestHandlerBaseParameters<Penality> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllPenalitiesDTO>>> Handle(GetAllPenalitiesQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Penality>(true);

            predicate = predicate
                .And(p => string.IsNullOrEmpty(request.CandidateId) || p.CandidateId == request.CandidateId)
                .And(p => !request.From.HasValue || p.CreatedDate >= request.From)
                .And(p => !request.To.HasValue || p.CreatedDate <= request.To);

            var query = await _repository
                .Get(predicate)
                .Include(p => p.Candidate)
                .OrderByDescending(p => p.CreatedDate)
                .Map<GetAllPenalitiesDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllPenalitiesDTO>>.Success(query);
        }
    }

}
