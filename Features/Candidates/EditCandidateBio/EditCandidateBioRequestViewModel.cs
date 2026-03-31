using AutoMapper;
using EasyTask.Features.Candidates.EditCandidateBio.Commands;
using FluentValidation;

namespace EasyTask.Features.Candidates.EditCandidateBio
{
    public record EditCandidateBioRequestViewModel(string ID, string Bio);
    public class EditCandidateBioRequestValidator : AbstractValidator<EditCandidateBioRequestViewModel>
    {
        public EditCandidateBioRequestValidator()
        {
        }
    }
    public class EditCandidateBioRequestProfile : Profile
    {
        public EditCandidateBioRequestProfile()
        {
            CreateMap<EditCandidateBioRequestViewModel, EditCandidateBioCommand>();
        }
    }
}
