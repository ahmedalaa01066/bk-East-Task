using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Documents.EditDocument.Commands;
using EasyTask.Models.Departments;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Departments.EditDepartment.Commands
{
    public record EditDepartmentCommand(string ID, string Name) : IRequestBase<bool>;
    public class EditDepartmentCommandHandler : RequestHandlerBase<Department, EditDepartmentCommand, bool>
    {
        public EditDepartmentCommandHandler(RequestHandlerBaseParameters<Department> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Department Department = new Department { ID = request.ID };
            Department.Name = request.Name;
            _repository.SaveIncluded(Department, nameof(Department.Name));
            _repository.SaveChanges();

            var EditDocument = await _mediator.Send(new EditDocumentCommand(request.Name, request.ID, DocumentType.Department));
            if (!EditDocument.IsSuccess)
                return RequestResult<bool>.Failure(EditDocument.ErrorCode);
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
