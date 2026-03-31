using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Vacations.DTOs;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Vacations;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Vacations.Queries
{
    public record GetAllVacationsQuery(string? Name, int pageIndex = 1,
        int pageSize = 100) : IRequestBase<PagingViewModel<GetAllVacationsDTO>>;
    public class GetAllVacationsQueryHandler : RequestHandlerBase<Vacation, GetAllVacationsQuery, PagingViewModel<GetAllVacationsDTO>>
    {
        public GetAllVacationsQueryHandler(RequestHandlerBaseParameters<Vacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllVacationsDTO>>> Handle(GetAllVacationsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Vacation>(true);
            predicate = predicate.And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name));

            var query =await _repository.Get(predicate).Map<GetAllVacationsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize); ;

            return RequestResult<PagingViewModel<GetAllVacationsDTO>>.Success(query);
        }
    }
}
