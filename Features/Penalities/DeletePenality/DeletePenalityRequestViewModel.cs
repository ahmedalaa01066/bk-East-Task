using AutoMapper;
using EasyTask.Features.Penalities.DeletePenality.Commands;
using FluentValidation;

namespace EasyTask.Features.Penalities.DeletePenality
{
    public record DeletePenalityRequestViewModel(string ID);
    public class DeletePenalityRequestValidator : AbstractValidator<DeletePenalityRequestViewModel>
    {
        public DeletePenalityRequestValidator()
        {
        }
    }
    public class DeletePenalityRequestProfile : Profile
    {
        public DeletePenalityRequestProfile()
        {
            CreateMap<DeletePenalityRequestViewModel, DeletePenalityCommand>();
        }
    }
}
