using AutoMapper;
using EasyTask.Features.Candidates.EditCandidateLevel.Command;
using FluentValidation;

namespace EasyTask.Features.Candidates.EditCandidateLevel
{
    public record EditCandidateLevelRequestViewModel(
        string ID,
        string LevelId
    );
    public class EditCandidateLevelRequestValidator : AbstractValidator<EditCandidateLevelRequestViewModel>
    {
        public EditCandidateLevelRequestValidator()
        {
        }
    }
    public class EditCandidateLevelRequestProfile : Profile
    {
        public EditCandidateLevelRequestProfile()
        {
            CreateMap<EditCandidateLevelRequestViewModel, EditCandidateLevelCommand>();
        }
    }
}
