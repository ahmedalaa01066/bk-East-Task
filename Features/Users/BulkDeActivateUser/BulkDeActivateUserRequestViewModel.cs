using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.BulkDeActivateUser.Orchestrator;

namespace EasyTask.Features.Users.BulkDeActivateUser
{
    public record BulkDeActivateUserRequestViewModel(List<string> IDs);
    public class BulkDeActivateUserRequestValidator : AbstractValidator<BulkDeActivateUserRequestViewModel>
    {
        public BulkDeActivateUserRequestValidator() { }
    }
    public class BulkDeActivateUserRequestProfile : Profile
    {
        public BulkDeActivateUserRequestProfile()
        {
            CreateMap<BulkDeActivateUserRequestViewModel, BulkDeActivateUserOrchestrator>();
        }
    }
}
