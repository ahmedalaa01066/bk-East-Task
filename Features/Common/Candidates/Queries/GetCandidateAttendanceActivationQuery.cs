using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetCandidateAttendanceActivationQuery(string? ID):IRequestBase<GetCandidateAttendanceActivationDTO>;
    public class GetCandidateAttendanceActivationQueryHandler : RequestHandlerBase<Candidate, GetCandidateAttendanceActivationQuery, GetCandidateAttendanceActivationDTO>
    {
        public GetCandidateAttendanceActivationQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<GetCandidateAttendanceActivationDTO>> Handle(GetCandidateAttendanceActivationQuery request, CancellationToken cancellationToken)
        {
            var ID=request.ID??_userState.UserID;
            var candidate= _repository.GetByID(ID).MapOne<GetCandidateAttendanceActivationDTO>();
            if (candidate == null)
            {
                return RequestResult<GetCandidateAttendanceActivationDTO>.Failure(ErrorCode.NotFound);
            }
            return RequestResult<GetCandidateAttendanceActivationDTO>.Success(candidate);
        }
    }
}
