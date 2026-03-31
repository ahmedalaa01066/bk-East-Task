using AutoMapper;
using EasyTask.Features.Common.VacationRequests.Queries;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.GetCandidateVacationRequests
{
    public record GetCandidateVacationRequestsRequestViewModel(
        int pageIndex = 1,
        int pageSize = 100);
    public class GetCandidateVacationRequestsRequestValidator : AbstractValidator<GetCandidateVacationRequestsRequestViewModel>
    {
        public GetCandidateVacationRequestsRequestValidator()
        {
        }
    }
    public class GetCandidateVacationRequestsRequestProfile : Profile
    {
        public GetCandidateVacationRequestsRequestProfile()
        {
            CreateMap<GetCandidateVacationRequestsRequestViewModel, GetCandidateVacationRequestsQuery>();
        }
    }
}
