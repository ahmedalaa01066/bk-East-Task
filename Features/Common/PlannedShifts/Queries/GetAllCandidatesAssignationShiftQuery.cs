using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.PlannedShifts.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.PlannedShifts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.PlannedShifts.Queries
{
    public record GetAllCandidatesAssignationShiftQuery(string? SearchText, int pageIndex = 1, int pageSize = 100):IRequestBase<PagingViewModel<GetAllCandidatesAssignationShiftDTO>>;
    public class GetAllCandidatesAssignationShiftQueryHandler : RequestHandlerBase<PlannedShift,
        GetAllCandidatesAssignationShiftQuery, PagingViewModel<GetAllCandidatesAssignationShiftDTO>>
    {
        public GetAllCandidatesAssignationShiftQueryHandler(RequestHandlerBaseParameters<PlannedShift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCandidatesAssignationShiftDTO>>> Handle(GetAllCandidatesAssignationShiftQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<PlannedShift>(true);

            predicate = predicate
                .And(p => string.IsNullOrEmpty(request.SearchText) || (p.Candidate != null &&
                     ((p.Candidate.FirstName + " " + p.Candidate.LastName).ToLower().Contains(request.SearchText)))
                    || (p.Shift != null && p.Shift.Name.ToLower().Contains(request.SearchText)));

            var query = await _repository
                .Get(predicate)
                .Include(p => p.Candidate).ThenInclude(p=>p.Department).Include(p=>p.Shift)
                .OrderByDescending(p => p.CreatedDate)
                .Map<GetAllCandidatesAssignationShiftDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllCandidatesAssignationShiftDTO>>.Success(query);
        }
    }
}
