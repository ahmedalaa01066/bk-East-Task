using AutoMapper;
using EasyTask.Features.Penalities.AddPenality.Command;
using FluentValidation;

namespace EasyTask.Features.Penalities.AddPenality
{
    public record AddPenalityRequestViewModel(string Description, string CandidateId);
    public class AddPenalityRequestValidator : AbstractValidator<AddPenalityRequestViewModel>
    {
        public AddPenalityRequestValidator() { }
    }
    public class AddPenalityRequestProfile : Profile
    {
        public AddPenalityRequestProfile()
        {
            CreateMap<AddPenalityRequestViewModel, AddPenalityCommand>();
        }
    }
}
