using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Users.Queries;

namespace EasyTask.Features.Users.GetAllUsers
{
    public record GetAllUsersRequestViewModel(string? Mobile, int pageIndex = 1,
        int pageSize = 100);
    public class GetAllUsersRequestValidator : AbstractValidator<GetAllUsersRequestViewModel>
    {
        public GetAllUsersRequestValidator()
        {
        }
    }
    public class GetAllUsersRequestProfile : Profile
    {
        public GetAllUsersRequestProfile()
        {
            CreateMap<GetAllUsersRequestViewModel, GetAllUsersQuery>();
        }
    }
}
