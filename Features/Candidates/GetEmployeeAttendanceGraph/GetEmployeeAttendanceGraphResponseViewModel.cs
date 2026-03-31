using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.GetEmployeeAttendanceGraph
{
    public class GetEmployeeAttendanceGraphResponseViewModel
    {
        public DateOnly Date { get; set; }
        public int AttendanceCount { get; set; }
        public List<VacationTypeCountDTO> Vacations { get; set; } = new();
    }
    public class GetEmployeeAttendanceGraphResponseProfile : Profile
    {
        public GetEmployeeAttendanceGraphResponseProfile()
        {
            CreateMap<EmployeeAttendanceGraphDTO, GetEmployeeAttendanceGraphResponseViewModel>();
        }
    }
}
