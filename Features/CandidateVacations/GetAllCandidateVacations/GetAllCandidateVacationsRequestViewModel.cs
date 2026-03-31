using AutoMapper;
using EasyTask.Features.Common.CandidateVacations.Queries;
using FluentValidation;

namespace EasyTask.Features.CandidateVacations.GetAllCandidateVacations
{
    public record GetAllCandidateVacationsRequestViewModel(string? SearchText, int pageIndex = 1,
        int pageSize = 100);
    public class GetAllCandidateVacationsRequestValidator : AbstractValidator<GetAllCandidateVacationsRequestViewModel>
    {
        public GetAllCandidateVacationsRequestValidator()
        {
        }
    }
    public class GetAllCandidateVacationsRequestProfile : Profile
    {
        public GetAllCandidateVacationsRequestProfile()
        {
            CreateMap<GetAllCandidateVacationsRequestViewModel, GetAllCandidateVacationsQuery>();
        }
    }
}
