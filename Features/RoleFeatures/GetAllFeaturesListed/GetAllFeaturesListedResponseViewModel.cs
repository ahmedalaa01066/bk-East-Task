using AutoMapper;
using EasyTask.Features.Common.RoleFeatures.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.RoleFeatures.GetAllFeaturesListed
{
    public record GetAllFeaturesListedResponseViewModel(string SectionName , List<RoleActiveFeatuersDTO> Features);
    public class GetAllFeaturesListedResponserofile : Profile
    {
        public GetAllFeaturesListedResponserofile()
        {
            CreateMap<GetAllFeaturesListedDTO, GetAllFeaturesListedResponseViewModel>();
        }
    }
}
