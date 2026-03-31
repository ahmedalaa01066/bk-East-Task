using EasyTask.Common.Requests;
using EasyTask.Models.ExternalMembers;

namespace EasyTask.Features.ExternalMembers.CreateExternalMember.Commands
{
    public record CreateExternalMemberCommand(
        string Name,
        string Email,
        string PhoneNumber,
        string Notes,
        string Description,
        string PositionId,
        string ExternalCompanyId
    ) : IRequestBase<bool>;
    public class CreateExternalMemberCommandHandler : RequestHandlerBase<ExternalMember, CreateExternalMemberCommand, bool>
    {
        public CreateExternalMemberCommandHandler(RequestHandlerBaseParameters<ExternalMember> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateExternalMemberCommand request, CancellationToken cancellationToken)
        {
            ExternalMember ExternalMember = new ExternalMember {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Notes = request.Notes,
                Description = request.Description,
                PositionId = request.PositionId,
                ExternalCompanyId = request.ExternalCompanyId
            };
            _repository.Add(ExternalMember);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
