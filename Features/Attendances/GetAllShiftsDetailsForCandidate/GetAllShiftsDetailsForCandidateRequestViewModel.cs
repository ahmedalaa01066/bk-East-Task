using AutoMapper;
using EasyTask.Features.Common.Attendances.Queries;
using FluentValidation;

namespace EasyTask.Features.Attendances.GetAllShiftsDetailsForCandidate
{
    public record GetAllShiftsDetailsForCandidateRequestViewModel
    (
        string CandidateId,
        DateOnly? From,
        DateOnly? TO,
        int pageIndex = 1,
        int pageSize = 100
    );
    public class GetAllShiftsDetailsForCandidateRequestValidator : AbstractValidator<GetAllShiftsDetailsForCandidateRequestViewModel>
    {
        public GetAllShiftsDetailsForCandidateRequestValidator()
        {
        }
    }
    public class GetAllShiftsDetailsForCandidateRequestProfile : Profile
    {
        public GetAllShiftsDetailsForCandidateRequestProfile()
        {
            CreateMap<GetAllShiftsDetailsForCandidateRequestViewModel, GetAllShiftsDetailsForCandidateQuery>();
        }
    }
}
