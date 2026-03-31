using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Departments;

namespace EasyTask.Features.Departments.ActiveDepartment.Commands
{
    public record ActiveDepartmentCommand(string ID) : IRequestBase<bool>;
    public class ActiveDepartmentCommandHandler : RequestHandlerBase<Department, ActiveDepartmentCommand, bool>
    {
        public ActiveDepartmentCommandHandler(RequestHandlerBaseParameters<Department> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(ActiveDepartmentCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Department department = new Department { ID = request.ID };
            department.IsActive = true;
            _repository.SaveIncluded(department, nameof(department.IsActive));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
