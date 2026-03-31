using AutoMapper;
using EasyTask.Features.Common.Attendances.Queries;
using FluentValidation;

namespace EasyTask.Features.Attendances.GetAllAttendancesForCandidate
{
    public record GetAllAttendancesForCandidateRequestViewModel
    (
        string CandidateId,
        DateOnly? From,
        DateOnly? TO,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllAttendancesForCandidateRequestValidator : AbstractValidator<GetAllAttendancesForCandidateRequestViewModel>
    {
        public GetAllAttendancesForCandidateRequestValidator()
        {
        }
    }
    public class GetAllAttendancesForCandidateRequestProfile : Profile
    {
        public GetAllAttendancesForCandidateRequestProfile()
        {
            CreateMap<GetAllAttendancesForCandidateRequestViewModel, GetAllAttendancesForCandidateQuery>();
        }
    }
}
