using AutoMapper;
using EasyTask.Features.Common.Attendances.DTOs;

namespace EasyTask.Features.Attendances.GetAllShiftsDetailsForCandidate
{
    public class GetAllShiftsDetailsForCandidateResponseViewModel
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Log { get; init; } = string.Empty;
    }
    public class GetAllShiftsDetailsForCandidateResponseProfile : Profile
    {
        public GetAllShiftsDetailsForCandidateResponseProfile()
        {
            CreateMap<GetAllShiftsDetailsForCandidateDTO, GetAllShiftsDetailsForCandidateResponseViewModel>();
        }
    }
}
