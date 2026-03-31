using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Courses.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Courses;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Courses.Queries
{
    public record GetAllCouesesWithCandidateNumberQuery(
        string? Name,
        DateTime? From,
        DateTime? To,
        int pageIndex = 1,
        int pageSize = 100
        ) : IRequestBase<PagingViewModel<GetAllCouesesWithCandidateNumberDTO>>;
    public class GetAllCouesesWithCandidateNumberQueryHandler : RequestHandlerBase<Course, GetAllCouesesWithCandidateNumberQuery, PagingViewModel<GetAllCouesesWithCandidateNumberDTO>>
    {
        public GetAllCouesesWithCandidateNumberQueryHandler(RequestHandlerBaseParameters<Course> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCouesesWithCandidateNumberDTO>>> Handle(GetAllCouesesWithCandidateNumberQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Course>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name) || c.InstructorName.Contains(request.Name))
                .And(t => !request.From.HasValue || t.CreatedDate >= request.From.Value)
                .And(t => !request.To.HasValue || t.CreatedDate <= request.To.Value);

            var model = await _repository
                .Get(predicate)
                .Map<GetAllCouesesWithCandidateNumberDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllCouesesWithCandidateNumberDTO>>.Success(model);
        }
    }
}
