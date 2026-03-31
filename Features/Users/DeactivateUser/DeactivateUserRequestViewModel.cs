using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.DeactivateUser.Commands;

namespace EasyTask.Features.Users.DeactivateUser
{
    public record DeactivateUserRequestViewModel(string ID);
    public class DeactivateUserRequestValidator:AbstractValidator<DeactivateUserRequestViewModel>
    {
        public DeactivateUserRequestValidator() { }
    }
    public class DeactivateUserRequestProfile : Profile
    {
        public DeactivateUserRequestProfile()
        {
            CreateMap<DeactivateUserRequestViewModel, DeactivateUserCommand>();
        }
    }
}
