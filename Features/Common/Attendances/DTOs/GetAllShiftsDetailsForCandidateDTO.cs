using AutoMapper;
using EasyTask.Models.Attendances;

namespace EasyTask.Features.Common.Attendances.DTOs
{
    public class GetAllShiftsDetailsForCandidateDTO
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Log { get; init; } = string.Empty;
    }
    public class GetAllShiftsDetailsForCandidateDTOProfile : Profile
    {
        public GetAllShiftsDetailsForCandidateDTOProfile()
        {
            CreateMap<Attendance, GetAllShiftsDetailsForCandidateDTO>();
        }
    }
}
