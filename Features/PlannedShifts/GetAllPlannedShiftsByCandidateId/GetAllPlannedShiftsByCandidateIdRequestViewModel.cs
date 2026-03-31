using AutoMapper;
using EasyTask.Features.Common.PlannedShifts.Queries;
using FluentValidation;

namespace EasyTask.Features.PlannedShifts.GetAllPlannedShiftsByCandidateId
{
    public record GetAllPlannedShiftsByCandidateIdRequestViewModel(string CandidateId);
    public class GetAllPlannedShiftsByCandidateIdRequestValidar : AbstractValidator<GetAllPlannedShiftsByCandidateIdRequestViewModel>
    {
        public GetAllPlannedShiftsByCandidateIdRequestValidar()
        {
        }
    }
    public class GetAllPlannedShiftsByCandidateIdRequestProfile : Profile
    {
        public GetAllPlannedShiftsByCandidateIdRequestProfile()
        {
            CreateMap<GetAllPlannedShiftsByCandidateIdRequestViewModel, GetAllPlannedShiftsByCandidateIdQuery>();
        }
    }
}
