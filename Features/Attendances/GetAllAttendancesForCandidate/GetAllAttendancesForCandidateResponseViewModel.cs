using AutoMapper;
using EasyTask.Features.Common.Attendances.DTOs;

namespace EasyTask.Features.Attendances.GetAllAttendancesForCandidate
{
    public record GetAllAttendancesForCandidateResponseViewModel(
        DateOnly ActualStartDate,
        TimeSpan FromTime,
        TimeSpan ToTime
    );
    public class GetAllAttendancesForCandidateResponseProfile : Profile
    {
        public GetAllAttendancesForCandidateResponseProfile()
        {
            CreateMap<GetAllAttendancesForCandidateDTO, GetAllAttendancesForCandidateResponseViewModel>();
        }
    }
}
