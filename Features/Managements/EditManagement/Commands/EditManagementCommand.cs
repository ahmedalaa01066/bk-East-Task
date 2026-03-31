using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Documents.EditDocument.Commands;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Managements.EditManagement.Commands
{
    public record EditManagementCommand(string ID, string Name, string? ManagerId) : IRequestBase<bool>;

    public class EditManagementCommandHandler : RequestHandlerBase<Management, EditManagementCommand, bool>
    {
        public EditManagementCommandHandler(RequestHandlerBaseParameters<Management> parameters) : base(parameters)
        { }

        public async override Task<RequestResult<bool>> Handle(EditManagementCommand request, CancellationToken cancellationToken)
        {
            var management = await _repository.GetByIDAsync(request.ID);
            if (management == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            var managerExists = await _repository.AnyAsync(
                     m => m.ManagerId == request.ManagerId && m.ID != request.ID);

            if (managerExists)
                return RequestResult<bool>.Failure(ErrorCode.DuplicateManager);


            string oldName = management.Name;
            string newName = request.Name;

            management.Name = request.Name;
            management.ManagerId = request.ManagerId;
            _repository.SaveIncluded(management, nameof(Management.Name), nameof(Management.ManagerId));
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }

}
