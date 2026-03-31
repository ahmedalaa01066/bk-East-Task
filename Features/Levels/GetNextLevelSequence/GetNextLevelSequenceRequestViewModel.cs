using AutoMapper;
using EasyTask.Features.Common.Levels.Queries;
using FluentValidation;

namespace EasyTask.Features.Levels.GetNextLevelSequence
{
    public record GetNextLevelSequenceRequestViewModel();
    public class GetNextLevelSequenceRequestValidator : AbstractValidator<GetNextLevelSequenceRequestViewModel>
    {
        public GetNextLevelSequenceRequestValidator()
        {
        }
    }
    public class GetNextLevelSequenceRequestProfile : Profile
    {
        public GetNextLevelSequenceRequestProfile()
        {
            CreateMap<GetNextLevelSequenceRequestViewModel, GetNextLevelSequenceQuery>();
        }
    }
}
