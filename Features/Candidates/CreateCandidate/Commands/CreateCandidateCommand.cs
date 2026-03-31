using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.CreateCandidate.Commands
{
    public record CreateCandidateCommand(
     string ID,
    string FirstName,
    string LastName,
    DateOnly JoiningDate,
    string Email,
    string PhoneNumber,
    CandidateStatus CandidateStatus,
    string? ManagerId,
    string? ManagementId,
    string? DepartmentId,
    string LevelId,
    string PositionId,
    string? PositionName,
    string Password,
    string ConfirmPassword,
    string? Bio,
     string? JobId
    ) : IRequestBase<bool>;
    public class CreateCandidateCommandHandler : RequestHandlerBase<Candidate, CreateCandidateCommand, bool>
    {
        public CreateCandidateCommandHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordHasher.Hash(request.Password);
            string JobCode = GenerateUniqueNumber();
            var candidate = new Candidate
            {
                ID = request.ID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                JoiningDate = request.JoiningDate,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CandidateStatus = request.CandidateStatus,
                ManagerId = request.ManagerId,
                ManagementId = request.ManagementId,
                DepartmentId = request.DepartmentId,
                LevelId = request.LevelId,
                PositionId = request.PositionId,
                PositionName = request.PositionName,
                Password = password,
                JobCode= JobCode,
                Bio=request.Bio,
                JobId = request.JobId
            };

            try
            {
                 _repository.Add(candidate);
                 _repository.SaveChanges();
                return RequestResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return RequestResult<bool>.Failure(ErrorCode.None, ex.Message);
            }
        }
        public static string GenerateUniqueNumber()
        {
            var millis = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            int uniquePart = (int)(millis % 1000000); 
            return uniquePart.ToString("D6");
        }
    }
}
