using AutoMapper;
using EasyTask.Features.Departments.EditDepartment.Commands;
using FluentValidation;

namespace EasyTask.Features.Departments.EditDepartment
{
    public record EditDepartmentRequestViewModel(string ID, string Name);
    public class EditDepartmentRequestValidator : AbstractValidator<EditDepartmentRequestViewModel>
    {
        public EditDepartmentRequestValidator() { }
    }
    public class EditDepartmentRequestProfile : Profile
    {
        public EditDepartmentRequestProfile()
        {
            CreateMap<EditDepartmentRequestViewModel, EditDepartmentCommand>();
        }
    }
}
