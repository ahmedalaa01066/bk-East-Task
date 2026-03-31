using AutoMapper;
using EasyTask.Features.Departments.ActiveDepartment.Commands;
using FluentValidation;

namespace EasyTask.Features.Departments.ActiveDepartment
{
    public record ActiveDepartmentRequestViewModel(string ID);
    public class ActiveDepartmentRequestValidator : AbstractValidator<ActiveDepartmentRequestViewModel>
    {
        public ActiveDepartmentRequestValidator() { }
    }
    public class ActiveDepartmentRequestProfile : Profile
    {
        public ActiveDepartmentRequestProfile()
        {
            CreateMap<ActiveDepartmentRequestViewModel, ActiveDepartmentCommand>();
        }
    }
}
