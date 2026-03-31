using EasyTask.Common.Requests;
using EasyTask.Features.Common.DefaultKPIs.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.DefaultKPIs;
using EasyTask.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.DefaultKPIs.Queries
{
    public record GetAllDefaultKPIsQuery(string? Name, KPIType? Type, double? Percentage) : IRequestBase<List<GetAllDefaultKPIsDTO>>;
    public class GetAllDefaultKPIsQueryHandler : RequestHandlerBase<DefaultKPI, GetAllDefaultKPIsQuery, List<GetAllDefaultKPIsDTO>>
    {
        public GetAllDefaultKPIsQueryHandler(RequestHandlerBaseParameters<DefaultKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<List<GetAllDefaultKPIsDTO>>> Handle(GetAllDefaultKPIsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<DefaultKPI>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name))
                .And(c => !request.Percentage.HasValue || c.Percentage == request.Percentage)
                .And(p => !request.Type.HasValue || p.Type == request.Type.Value);

            var query = await _repository
                .Get(predicate)
                 .Map<GetAllDefaultKPIsDTO>().ToListAsync();

            return RequestResult<List<GetAllDefaultKPIsDTO>>.Success(query);
        }
    }
}
