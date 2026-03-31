using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.WorkPackages.Queries;

namespace EasyTask.Features.WorkPackages.WorkPackageSelectList
{
    public record WorkPackageSelectListRequestViewModel();
    public class WorkPackageSelectListRequestValidator : AbstractValidator<WorkPackageSelectListRequestViewModel>
    {
        public WorkPackageSelectListRequestValidator() { }
    }
    public class WorkPackageSelectListRequestProfile : Profile
    {
        public WorkPackageSelectListRequestProfile() {
            CreateMap<WorkPackageSelectListRequestViewModel, WorkPackageSelectListQuery>();
        }
    }
}
