using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Positions.Queries;

namespace EasyTask.Features.Positions.GetPositionById
{
    public record GetPositionByIdRequestViewModel(string ID);
    public class GetPositionByIdRequestValidator : AbstractValidator<GetPositionByIdRequestViewModel>
    {
        public GetPositionByIdRequestValidator()
        {
        }
    }
    public class GetPositionByIdRequestProfile : Profile
    {
        public GetPositionByIdRequestProfile() {
            CreateMap<GetPositionByIdRequestViewModel, GetPositionByIdQuery>();
        }
    }
}
