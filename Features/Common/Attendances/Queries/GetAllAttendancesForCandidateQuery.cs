using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Attendances.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Attendances;
using PredicateExtensions.Core;

namespace EasyTask.Features.Common.Attendances.Queries
{
    public record GetAllAttendancesForCandidateQuery(
        string CandidateId,
        DateOnly? From,
        DateOnly? TO,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllAttendancesForCandidateDTO>>;
    public class GetAllAttendancesForCandidateQueryHandler : RequestHandlerBase<Attendance, GetAllAttendancesForCandidateQuery, PagingViewModel<GetAllAttendancesForCandidateDTO>>
    {
        public GetAllAttendancesForCandidateQueryHandler(RequestHandlerBaseParameters<Attendance> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllAttendancesForCandidateDTO>>> Handle(GetAllAttendancesForCandidateQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Attendance>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.CandidateId) || c.CandidateId.Contains(request.CandidateId))
                .And(t => !request.From.HasValue || DateOnly.FromDateTime(t.ActualStartDate) >= request.From.Value)
                .And(t => !request.TO.HasValue || DateOnly.FromDateTime(t.ActualEndDate.Value) <= request.TO.Value);

            var model = await _repository
                .Get(predicate)
                .Map<GetAllAttendancesForCandidateDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllAttendancesForCandidateDTO>>.Success(model);
        }
    }
}
