using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Levels.Queries;

namespace EasyTask.Features.Levels.GetLevelById
{
    public record GetLevelByIdRequestViewModel(string ID);
    public class GetLevelByIdRequestValidator : AbstractValidator<GetLevelByIdRequestViewModel>
    {
        public GetLevelByIdRequestValidator()
        {
        }
    }
    public class GetLevelByIdRequestProfile : Profile
    {
        public GetLevelByIdRequestProfile() {
            CreateMap<GetLevelByIdRequestViewModel, GetLevelByIdQuery>();
        }
    }
}
