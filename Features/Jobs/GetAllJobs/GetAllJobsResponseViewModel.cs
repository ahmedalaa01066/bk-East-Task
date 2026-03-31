using AutoMapper;
using EasyTask.Features.Common.Jobs.DTOs;

namespace EasyTask.Features.Jobs.GetAllJobs
{
    public record GetAllJobsResponseViewModel(string ID, string Name, string Description, string JobCode, string ManagementId, string ManagementName);
    public class GetAllJobsResponseProfile : Profile
    {
        public GetAllJobsResponseProfile()
        {
            CreateMap<GetAllJobsDTO, GetAllJobsResponseViewModel>();
        }
    }
}
