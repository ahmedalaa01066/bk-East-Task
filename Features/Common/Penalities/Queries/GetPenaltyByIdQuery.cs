using EasyTask.Common.Requests;
using EasyTask.Features.Common.Penalities.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Penalities;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Penalities.Queries
{
    public record GetPenaltyByIdQuery(string ID) : IRequestBase<GetPenaltyByIdDTO>;
    public class GetPenaltyByIdQueryHandler : RequestHandlerBase<Penality, GetPenaltyByIdQuery, GetPenaltyByIdDTO>
    {
        public GetPenaltyByIdQueryHandler(RequestHandlerBaseParameters<Penality> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<GetPenaltyByIdDTO>> Handle(GetPenaltyByIdQuery request, CancellationToken cancellationToken)
        {
            var Penalty = _repository.Get(p => p.ID == request.ID)
                .Include(p => p.Candidate)
                .MapOne<GetPenaltyByIdDTO>();
            return RequestResult<GetPenaltyByIdDTO>.Success(Penalty);
        }
    }
}
