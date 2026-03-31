using AutoMapper;
using EasyTask.Features.Common.Managements.Queries;
using FluentValidation;

namespace EasyTask.Features.Managements.SelectManagementListByCourseId
{
    public record SelectManagementListByCourseIdRequestViewModel(string? CourseId);
    public class SelectManagementListByCourseIdRequestValidator : AbstractValidator<SelectManagementListByCourseIdRequestViewModel>
    {
        public SelectManagementListByCourseIdRequestValidator()
        {
        }
    }
    public class SelectManagementListByCourseIdRequestProfile : Profile
    {
        public SelectManagementListByCourseIdRequestProfile()
        {
            CreateMap<SelectManagementListByCourseIdRequestViewModel, SelectManagementListByCourseIdQuery>();
        }
    }
}
