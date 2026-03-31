using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Users.EditUser.Commands;

namespace EasyTask.Features.Users.EditClient
{
    public record EditUserRequestViewModel(string ID, string Email, string Name, string Mobile);
    public class EditUserRequestValidator:AbstractValidator<EditUserRequestViewModel>
    {
        public EditUserRequestValidator() { }
    }
    public class EditUserRequestProfile : Profile
    {
        public EditUserRequestProfile()
        {
            CreateMap<EditUserRequestViewModel, EditUserCommand>();
        }
    }
}
