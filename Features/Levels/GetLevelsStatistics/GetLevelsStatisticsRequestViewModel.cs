using AutoMapper;
using EasyTask.Features.Common.Levels.Queries;
using FluentValidation;

namespace EasyTask.Features.Levels.GetLevelsStatistics
{
    public record GetLevelsStatisticsRequestViewModel();
    public class GetLevelsStatisticsRequestValidator : AbstractValidator<GetLevelsStatisticsRequestViewModel>
    {
        public GetLevelsStatisticsRequestValidator()
        {
        }
    }
    public class GetLevelsStatisticsRequestProfile : Profile
    {
        public GetLevelsStatisticsRequestProfile()
        {
            CreateMap<GetLevelsStatisticsRequestViewModel, GetLevelsStatisticsQuery>();
        }
    }
}
