using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.ManagerSelectList
{
    public record ManagerSelectListRequestViewModel();
    public class ManagerSelectListRequestValidator : AbstractValidator<ManagerSelectListRequestViewModel>
    {
        public ManagerSelectListRequestValidator()
        {
        }
    }
    public class ManagerSelectListRequestProfile : Profile
    {
        public ManagerSelectListRequestProfile()
        {
            CreateMap<ManagerSelectListRequestViewModel, ManagerSelectListQuery>();
        }
    }
}
