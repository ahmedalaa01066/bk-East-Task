using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.ActivateUser.Commands;

namespace EasyTask.Features.Users.ActivateUser
{
    public record ActivateUserRequestViewModel(string ID);
    public class ActivateUserRequestValidator:AbstractValidator<ActivateUserRequestViewModel>
    {
        public ActivateUserRequestValidator() { }
    }
    public class ActivateUserRequestProfile : Profile
    {
        public ActivateUserRequestProfile()
        {
            CreateMap<ActivateUserRequestViewModel, ActivateUserCommand>();
        }
    }
}
