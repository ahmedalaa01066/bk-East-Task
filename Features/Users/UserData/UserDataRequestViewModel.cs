using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Users.Queries;

namespace EasyTask.Features.Users.UserData
{
    public record UserDataRequestViewModel();
    public class UserDataRequestValidator : AbstractValidator<UserDataRequestViewModel>
    {
        public UserDataRequestValidator() { }
    }
    public class UserDataRequestProfile : Profile
    {
        public UserDataRequestProfile() {
            CreateMap<UserDataRequestViewModel, UserDataQuery>();
        }
    }
}
