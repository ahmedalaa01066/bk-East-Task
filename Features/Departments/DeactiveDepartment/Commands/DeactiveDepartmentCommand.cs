using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Departments;

namespace EasyTask.Features.Departments.DeactiveDepartment.Commands
{
    public record DeactiveDepartmentCommand(string ID) : IRequestBase<bool>;
    public class DeactiveDepartmentCommandHandler : RequestHandlerBase<Department, DeactiveDepartmentCommand, bool>
    {
        public DeactiveDepartmentCommandHandler(RequestHandlerBaseParameters<Department> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeactiveDepartmentCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Department department = new Department { ID = request.ID };
            department.IsActive = false;
            _repository.SaveIncluded(department, nameof(department.IsActive));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
