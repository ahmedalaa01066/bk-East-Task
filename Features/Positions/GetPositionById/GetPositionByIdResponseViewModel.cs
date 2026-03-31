using AutoMapper;
using EasyTask.Features.Common.Positions.DTOs;

namespace EasyTask.Features.Positions.GetPositionById
{
    public record GetPositionByIdResponseViewModel(string Id, string Name);
    public class GetPositionByIdResponseProfile : Profile
    {
        public GetPositionByIdResponseProfile()
        {
            CreateMap<GetPositionByIdDTO, GetPositionByIdResponseViewModel>();
        }
    }
}
