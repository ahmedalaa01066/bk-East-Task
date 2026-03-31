
using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Managements.Queries;

namespace EasyTask.Features.Managements.SelectManagementList
{
    public record SelectManagementListRequestViewModel(string? JobId );
    public class SelectManagementListRequestValidator : AbstractValidator<SelectManagementListRequestViewModel>
    {
        public SelectManagementListRequestValidator()
        {
        }
    }
    public class SelectManagementListRequestProfile : Profile
    {
        public SelectManagementListRequestProfile() {
            CreateMap<SelectManagementListRequestViewModel, SelectManagementListQuery>();
        } 
    }
}
