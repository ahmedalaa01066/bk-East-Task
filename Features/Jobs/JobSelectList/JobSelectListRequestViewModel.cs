using AutoMapper;
using EasyTask.Features.Common.Jobs.Quereies;
using FluentValidation;

namespace EasyTask.Features.Jobs.JobSelectList
{
    public record JobSelectListRequestViewModel(string? ManagementId);
    public class JobSelectListRequestValidator : AbstractValidator<JobSelectListRequestViewModel>
    {
        public JobSelectListRequestValidator()
        {
        }
    }
    public class JobSelectListRequestProfile : Profile
    {
        public JobSelectListRequestProfile()
        {
            CreateMap<JobSelectListRequestViewModel, JobSelectListQuery>();
        }
    }
}
