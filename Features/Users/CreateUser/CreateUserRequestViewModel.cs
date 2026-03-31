using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Users.CreateUser.Commands;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Users.CreateUser
{
    public record CreateUserRequestViewModel(
        string Name, 
        string Email,
        string Password,
        string ConfirmPassword,
        string Mobile, 
        Role RoleId,
        VerifyStatus VerifyStatus = VerifyStatus.Verified
    );
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequestViewModel>
    {
        public CreateUserRequestValidator()
        {

        }
    }
    public class CreateUserRequestProfile : Profile
    {
        public CreateUserRequestProfile()
        {
            CreateMap<CreateUserRequestViewModel, CreateUserCommand>();
        }
    }
}
