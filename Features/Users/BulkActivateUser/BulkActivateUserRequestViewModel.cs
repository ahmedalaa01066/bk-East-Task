using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.BulkActivateUser.Orchestrator;

namespace EasyTask.Features.Users.BulkActivateUser
{
    public record BulkActivateUserRequestViewModel(List<string> IDs);
    public class BulkActivateUserRequestValidator : AbstractValidator<BulkActivateUserRequestViewModel>
    {
        public BulkActivateUserRequestValidator() { }
    }
    public class BulkActivateUserRequestProfile : Profile
    {
        public BulkActivateUserRequestProfile()
        {
            CreateMap<BulkActivateUserRequestViewModel, BulkActivateUserOrchestrator>();
        }
    }
}
