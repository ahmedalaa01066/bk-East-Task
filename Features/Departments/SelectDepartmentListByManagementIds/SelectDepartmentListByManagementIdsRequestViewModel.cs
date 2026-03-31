using AutoMapper;
using EasyTask.Features.Common.Departments.Queries;
using FluentValidation;

namespace EasyTask.Features.Departments.SelectDepartmentListByManagementIds
{
    public record SelectDepartmentListByManagementIdsRequestViewModel(List<string>? ManagementIds, string? CourseId);
    public class SelectDepartmentListByManagementIdsRequestValidator : AbstractValidator<SelectDepartmentListByManagementIdsRequestViewModel>
    {
        public SelectDepartmentListByManagementIdsRequestValidator()
        {
        }
    }
    public class SelectDepartmentListByManagementIdsRequestProfile : Profile
    {
        public SelectDepartmentListByManagementIdsRequestProfile()
        {
            CreateMap<SelectDepartmentListByManagementIdsRequestViewModel, SelectDepartmentListByManagementIdsQuery>();
        }
    }
}
