using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.GetCandidateAttendanceActivation
{
    public record GetCandidateAttendanceActivationResponseViewModel(string ID, AttendanceActivation AttendanceActivation);
    public class GetCandidateAttendanceActivationResponseProfile : Profile
    {
        public GetCandidateAttendanceActivationResponseProfile()
        {
            CreateMap<GetCandidateAttendanceActivationDTO, GetCandidateAttendanceActivationResponseViewModel>();
        }
    }
}
