using AutoMapper;
using EasyTask.Features.Common.Positions.Queries;
using FluentValidation;

namespace EasyTask.Features.Positions.GetAllPositions
{
    public record GetAllPositionsRequestViewModel(string? Name, int pageIndex = 1,
        int pageSize = 100);
    public class GetAllPositionsRequestValidator : AbstractValidator<GetAllPositionsRequestViewModel>
    {
        public GetAllPositionsRequestValidator()
        {
        }
    }
    public class GetAllPositionsRequestProfile : Profile
    {
        public GetAllPositionsRequestProfile()
        {
            CreateMap<GetAllPositionsRequestViewModel, GetAllPositionsQuery>();
        }
    }
}
