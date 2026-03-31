using AutoMapper;
using EasyTask.Features.Common.DefaultKPIs.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.DefaultKPIs.GetAllDefaultKPIs
{
    public record GetAllDefaultKPIsRequestViewModel(string? Name, KPIType? Type, double? Percentage, int pageIndex = 1, int pageSize = 100);
    public class GetAllDefaultKPIsRequestValidator : AbstractValidator<GetAllDefaultKPIsRequestViewModel>
    {
        public GetAllDefaultKPIsRequestValidator()
        {
        }
    }
    public class GetAllDefaultKPIsRequestProfile : Profile
    {
        public GetAllDefaultKPIsRequestProfile()
        {
            CreateMap<GetAllDefaultKPIsRequestViewModel, GetAllDefaultKPIsPagingQuery>();
        }
    }
}
