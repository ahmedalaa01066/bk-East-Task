using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.GetAllCandidatesWithKPIs
{
    public record GetAllCandidatesWithKPIsRequestViewModel(string? SearchText,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllCandidatesWithKPIsRequestValidator : AbstractValidator<GetAllCandidatesWithKPIsRequestViewModel>
    {
        public GetAllCandidatesWithKPIsRequestValidator()
        {
        }
    }
    public class GetAllCandidatesWithKPIsRequestProfile : Profile
    {
        public GetAllCandidatesWithKPIsRequestProfile()
        {
            CreateMap<GetAllCandidatesWithKPIsRequestViewModel, GetAllCandidatesWithKPIsQuery>();
        }
    }
}
