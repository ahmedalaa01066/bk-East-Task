using AutoMapper;
using EasyTask.Features.CandidateCourses.SetActualStartDate.Commands;
using FluentValidation;

namespace EasyTask.Features.CandidateCourses.SetActualStartDate
{
    public record SetActualStartDateRequestViewModel(string CandidateId, string CourseId, DateOnly ActualStartDate);
    public class SetActualStartDateRequestValidator : AbstractValidator<SetActualStartDateRequestViewModel>
    {
        public SetActualStartDateRequestValidator()
        {
        }
    }
    public class SetActualStartDateRequestProfile : Profile
    {
        public SetActualStartDateRequestProfile()
        {
            CreateMap<SetActualStartDateRequestViewModel, SetActualStartDateCommand>();
        }
    }
}
