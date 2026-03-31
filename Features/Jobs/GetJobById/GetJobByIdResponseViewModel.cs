using AutoMapper;
using EasyTask.Features.Common.Jobs.DTOs;

namespace EasyTask.Features.Jobs.GetJobById
{
    public record GetJobByIdResponseViewModel(string ID, string Name, string Description, string ManagementId, string ManagementName);
    public class GetJobByIdResponseProfile : Profile
    {
        public GetJobByIdResponseProfile()
        {
            CreateMap<GetJobByIdDTO, GetJobByIdResponseViewModel>();
        }
    }
}
