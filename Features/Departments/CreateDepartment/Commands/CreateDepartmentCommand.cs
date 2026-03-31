using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Departments;

namespace EasyTask.Features.Departments.CreateDepartment.Commands
{
    public record CreateDepartmentCommand(string Name, string ManagementId,string ManagementName) : IRequestBase<string>;
    public class CreateDepartmentCommandHandler : RequestHandlerBase<Department, CreateDepartmentCommand, string>
    {
        public CreateDepartmentCommandHandler(RequestHandlerBaseParameters<Department> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department Department = new Department {
                Name = request.Name,
                ManagementId = request.ManagementId,
                IsActive = true ,
                Code = GenerateGenericCode.Generate("DP")
            };
            _repository.Add(Department);
            _repository.SaveChanges();
            return RequestResult<string>.Success(Department.ID);
        }
    }
}
