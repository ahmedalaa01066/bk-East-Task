using AutoMapper;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public record GetCandidateAttendanceActivationDTO(string ID, AttendanceActivation AttendanceActivation);
    public class GetCandidateAttendanceActivationProfile : Profile
    {
        public GetCandidateAttendanceActivationProfile()
        {
            CreateMap<Candidate, GetCandidateAttendanceActivationDTO>();
        }
    }
}
