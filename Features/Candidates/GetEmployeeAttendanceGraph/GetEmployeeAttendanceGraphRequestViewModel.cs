using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.GetEmployeeAttendanceGraph
{
    public record GetEmployeeAttendanceGraphRequestViewModel(DateOnly FromDate, DateOnly ToDate);
    public class GetEmployeeAttendanceGraphRequestValidator : AbstractValidator<GetEmployeeAttendanceGraphRequestViewModel>
    {
        public GetEmployeeAttendanceGraphRequestValidator()
        {
        }
    }
    public class GetEmployeeAttendanceGraphRequestProfile : Profile
    {
        public GetEmployeeAttendanceGraphRequestProfile()
        {
            CreateMap<GetEmployeeAttendanceGraphRequestViewModel, GetEmployeeAttendanceGraphQuery>();
        }
    }
}
