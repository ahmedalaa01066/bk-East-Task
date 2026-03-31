using AutoMapper;
using EasyTask.Features.Common.PlannedShifts.Queries;
using FluentValidation;

namespace EasyTask.Features.PlannedShifts.GetAllCandidatesAssignationShift
{
    public record GetAllCandidatesAssignationShiftRequestViewModel(string? SearchText, int pageIndex = 1, int pageSize = 100);
    public class GetAllCandidatesAssignationShiftRequestValidar : AbstractValidator<GetAllCandidatesAssignationShiftRequestViewModel>
    {
        public GetAllCandidatesAssignationShiftRequestValidar()
        {
        }
    }
    public class GetAllCandidatesAssignationShiftRequestProfile : Profile
    {
        public GetAllCandidatesAssignationShiftRequestProfile()
        {
            CreateMap<GetAllCandidatesAssignationShiftRequestViewModel, GetAllCandidatesAssignationShiftQuery>();
        }
    }
}
