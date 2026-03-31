using AutoMapper;
using EasyTask.Features.Departments.DeactiveDepartment.Commands;
using FluentValidation;

namespace EasyTask.Features.Departments.DeactiveDepartment
{
    public record DeactiveDepartmentRequestViewModel(string ID);
    public class DeactiveDepartmentRequestValidator : AbstractValidator<DeactiveDepartmentRequestViewModel>
    {
        public DeactiveDepartmentRequestValidator() { }
    }
    public class DeactiveDepartmentRequestProfile : Profile
    {
        public DeactiveDepartmentRequestProfile()
        {
            CreateMap<DeactiveDepartmentRequestViewModel, DeactiveDepartmentCommand>();
        }
    }
}
