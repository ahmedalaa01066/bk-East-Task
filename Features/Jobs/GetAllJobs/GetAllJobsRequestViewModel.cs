using AutoMapper;
using EasyTask.Features.Common.Jobs.DTOs;
using FluentValidation;

namespace EasyTask.Features.Jobs.GetAllJobs
{
    public record GetAllJobsRequestViewModel(string? SearchText, int pageIndex = 1, int pageSize = 100);
    public class GetAllJobsRequestValidator : AbstractValidator<GetAllJobsRequestViewModel>
    {
        public GetAllJobsRequestValidator()
        {
        }
    }
    public class GetAllJobsRequestProfile : Profile
    {
        public GetAllJobsRequestProfile()
        {
            CreateMap<GetAllJobsRequestViewModel, GetAllJobsQuery>();
        }
    }
}
