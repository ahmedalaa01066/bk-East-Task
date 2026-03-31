using EasyTask.Common.Requests;
using EasyTask.Models.CandidatePermissions;

namespace EasyTask.Features.CandidatePermissions.CreateCandidatePermission.Commands
{
    public record CreateCandidatePermissionCommand(
        string CandidateId, 
        string PermissionId, 
        TimeSpan NumOfHoursOfPermission,
        DateTime PermissionMonth,
        TimeSpan HoursLeftInMonth
    ) : IRequestBase<string>;
    public class CreateCandidatePermissionCommandHandler : RequestHandlerBase<CandidatePermission, CreateCandidatePermissionCommand, string>
    {
        public CreateCandidatePermissionCommandHandler(RequestHandlerBaseParameters<CandidatePermission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateCandidatePermissionCommand request, CancellationToken cancellationToken)
        {
            CandidatePermission CandidatePermission =
                new CandidatePermission { 
                    CandidateId = request.CandidateId,
                    PermissionId = request.PermissionId,
                    NumOfHoursOfPermission = request.NumOfHoursOfPermission, 
                    PermissionMonth = request.PermissionMonth, 
                    HoursLeftInMonth = request.HoursLeftInMonth 
                };
            _repository.Add(CandidatePermission);
            _repository.SaveChanges();
            return RequestResult<string>.Success(CandidatePermission.ID);
        }
    }
}
