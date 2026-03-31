using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Jobs.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Jobs;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Jobs.Quereies
{
    public record GetJobByIdQuery(string ID):IRequestBase<GetJobByIdDTO>;
    public class GetJobByIdQueryHandler : RequestHandlerBase<Job, GetJobByIdQuery, GetJobByIdDTO>
    {
        public GetJobByIdQueryHandler(RequestHandlerBaseParameters<Job> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetJobByIdDTO>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = _repository.Get(c=>c.ID==request.ID).Include(c=>c.Management).FirstOrDefault().MapOne<GetJobByIdDTO>();
            if (job == null)
            {
                return RequestResult<GetJobByIdDTO>.Failure(ErrorCode.NotFound);
            }
            return RequestResult<GetJobByIdDTO>.Success(job);
        }
    }
}
