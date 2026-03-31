using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Managements;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Managements.Queries
{
    public record GetManagementByIDQuery(string ID):IRequestBase<GetManagementDTO>;
    public class GetManagementByIDQueryHandler : RequestHandlerBase<Management, GetManagementByIDQuery, GetManagementDTO>
    {
        public GetManagementByIDQueryHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetManagementDTO>> Handle(GetManagementByIDQuery request, CancellationToken cancellationToken)
        {
            var managementEntity = _repository.Get(m => m.ID == request.ID)
                .Include(m => m.Departments)
                .FirstOrDefault();

            if (managementEntity == null)
            {
                return RequestResult<GetManagementDTO>.Failure(ErrorCode.NotFound);
            }

            var managementDto = managementEntity.MapOne<GetManagementDTO>();
            return RequestResult<GetManagementDTO>.Success(managementDto);

        }
    }
}
