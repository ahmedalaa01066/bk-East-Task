using AutoMapper;
using EasyTask.Features.Common.Penalities.Queries;
using FluentValidation;

namespace EasyTask.Features.Penalities.GetAllPenalities
{
    public record GetAllPenalitiesRequestViewModel
    (string? CandidateId, DateTime? From, DateTime? To, int pageIndex = 1, int pageSize = 100);
    public class GetAllPenalitiesRequestValidator : AbstractValidator<GetAllPenalitiesRequestViewModel>
    {
        public GetAllPenalitiesRequestValidator() { }
    }
    public class GetAllPenalitiesRequestProfile : Profile
    {
        public GetAllPenalitiesRequestProfile()
        {
            CreateMap<GetAllPenalitiesRequestViewModel, GetAllPenalitiesQuery>();
        }
    }
}
