using EasyTask.Models.Candidates;
using AutoMapper;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class EmployeeAttendanceGraphDTO
    {
        public DateOnly Date { get; set; }
        public int AttendanceCount { get; set; }
        public List<VacationTypeCountDTO> Vacations { get; set; } = new();
    }

    public class VacationTypeCountDTO
    {
        public string VacationType { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class EmployeeAttendanceGraphDTOProfile : Profile
    {
        public EmployeeAttendanceGraphDTOProfile()
        {
            CreateMap<Candidate, EmployeeAttendanceGraphDTO>();
        }
    }
}
