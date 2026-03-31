using AutoMapper;
using EasyTask.Features.Common.Departments.Queries;
using FluentValidation;

namespace EasyTask.Features.Departments.SelectDepartmentList
{
    public record SelectDepartmentListRequestViewModel(string? ManagementId);
    public class SelectDepartmentListRequestValidator : AbstractValidator<SelectDepartmentListRequestViewModel>
    {
        public SelectDepartmentListRequestValidator() { }
    }
    public class SelectDepartmentListRequestProfile : Profile
    {
        public SelectDepartmentListRequestProfile()
        {
            CreateMap<SelectDepartmentListRequestViewModel, SelectDepartmentListQuery>();
        }
    }

}
