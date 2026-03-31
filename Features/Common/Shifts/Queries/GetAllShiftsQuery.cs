using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateCourses.Queries;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Features.Common.PlannedShifts.Queries;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Courses;
using EasyTask.Models.PlannedShifts;
using EasyTask.Models.Shifts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Shifts.Queries
{
    public record GetAllShiftsQuery(string? SearchText, int pageIndex = 1,
       int pageSize = 100) : IRequestBase<PagingViewModel<GetAllShiftsDTO>>;
    public class GetAllShiftsQueryHandler : RequestHandlerBase<Shift, GetAllShiftsQuery, PagingViewModel<GetAllShiftsDTO>>
    {
        public GetAllShiftsQueryHandler(RequestHandlerBaseParameters<Shift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllShiftsDTO>>> Handle(GetAllShiftsQuery request,CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Shift>(true);
            predicate = predicate.And(c => string.IsNullOrEmpty(request.SearchText) || c.Name.Contains(request.SearchText));

            var query = _repository.Get(predicate)
                .Include(s => s.PlannedShifts)
                    .ThenInclude(ps => ps.Candidate)
                        .ThenInclude(c => c.Management); 

            var model = await query
                .Map<GetAllShiftsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            foreach (var item in model.Items)
            {
                var result = await _mediator.Send(new GetAllCandidatesManagmentsForShiftQuery(item.ID));
                item.Assignation = result.Data.ToList();
            }

            return RequestResult<PagingViewModel<GetAllShiftsDTO>>.Success(model);
        }

    }
}
