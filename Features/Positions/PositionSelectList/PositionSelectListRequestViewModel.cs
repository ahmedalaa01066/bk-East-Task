using AutoMapper;
using EasyTask.Features.Common.Positions.Queries;
using FluentValidation;

namespace EasyTask.Features.Positions.PositionSelectList
{
    public record PositionSelectListRequestViewModel();
    public class PositionSelectListRequestValidator:AbstractValidator<PositionSelectListRequestViewModel>
    {
        public PositionSelectListRequestValidator() { }
    }
    public class PositionSelectListRequestProfile : Profile
    {
        public PositionSelectListRequestProfile()
        {
            CreateMap<PositionSelectListRequestViewModel, PositionSelectListQuery>();
        }
    }
}
