using AutoMapper;
using EasyTask.Features.Common.Penalities.DTOs;

namespace EasyTask.Features.Penalities.GetPenaltyById
{
    public record GetPenaltyByIdResponseViewModel(string Id, string Name);
    public class GetPenaltyByIdResponseProfile : Profile
    {
        public GetPenaltyByIdResponseProfile()
        {
            CreateMap<GetPenaltyByIdDTO, GetPenaltyByIdResponseViewModel>();
        }
    }
}
