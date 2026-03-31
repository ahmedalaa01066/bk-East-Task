using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Departments;

namespace EasyTask.Features.Departments.DeleteDepartment.Commands
{
    public record DeleteDepartmentCommand(string ID) : IRequestBase<bool>;
    public class DeleteDepartmentCommandHandler : RequestHandlerBase<Department, DeleteDepartmentCommand, bool>
    {
        public DeleteDepartmentCommandHandler(RequestHandlerBaseParameters<Department> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            _repository.Delete(request.ID);
            _repository.SaveChanges();
            return await Task.FromResult(RequestResult<bool>.Success(true));
        }
    }
}
