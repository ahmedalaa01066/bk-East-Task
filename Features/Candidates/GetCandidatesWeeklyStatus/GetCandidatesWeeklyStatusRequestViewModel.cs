using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.GetCandidatesWeeklyStatus
{
    public record GetCandidatesWeeklyStatusRequestViewModel(string? SearchText,DateOnly? StartDate, DateOnly? EndDate, int PageIndex = 1, int PageSize = 10);
    public class GetCandidatesWeeklyStatusRequestValidator : AbstractValidator<GetCandidatesWeeklyStatusRequestViewModel>
    {
        public GetCandidatesWeeklyStatusRequestValidator()
        {
        }
    }
    public class GetCandidatesWeeklyStatusRequestProfile : Profile
    {
        public GetCandidatesWeeklyStatusRequestProfile()
        {
            CreateMap<GetCandidatesWeeklyStatusRequestViewModel, GetCandidatesWeeklyStatusQuery>();
        }
    }
}
