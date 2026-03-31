using AutoMapper;
using EasyTask.Features.Departments.DeleteDepartment.Commands;
using FluentValidation;

namespace EasyTask.Features.Departments.DeleteDepartment
{
    public record DeleteDepartmentRequestViewModel(string ID);
    public class DeleteDepartmentRequestValidator : AbstractValidator<DeleteDepartmentRequestViewModel>
    {
        public DeleteDepartmentRequestValidator() { }
    }
    public class DeleteDepartmentRequestProfile : Profile
    {
        public DeleteDepartmentRequestProfile()
        {
            CreateMap<DeleteDepartmentRequestViewModel, DeleteDepartmentCommand>();
        }
    }
}
