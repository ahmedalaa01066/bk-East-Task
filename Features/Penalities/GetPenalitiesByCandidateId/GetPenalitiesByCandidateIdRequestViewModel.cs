using AutoMapper;
using EasyTask.Features.Common.Penalities.Queries;
using FluentValidation;

namespace EasyTask.Features.Penalities.GetPenalitiesByCandidateId
{
    public record GetPenalitiesByCandidateIdRequestViewModel(string? CandidateId, DateTime? From, DateTime? To,
        int pageIndex = 1, int pageSize = 100);
    public class GetPenalitiesByCandidateIdRequestValidator : AbstractValidator<GetPenalitiesByCandidateIdRequestViewModel>
    {
        public GetPenalitiesByCandidateIdRequestValidator()
        {
        }
    }
    public class GetPenalitiesByCandidateIdRequestProfile : Profile
    {
        public GetPenalitiesByCandidateIdRequestProfile()
        {
            CreateMap<GetPenalitiesByCandidateIdRequestViewModel, GetPenalitiesByCandidateIdQuery>();
        }
    }
}
