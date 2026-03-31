using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Users.Queries;

namespace EasyTask.Features.Users.GetUserByID
{
    public record GetUserByIDRequestViewModel(string ID);
    public class GetUserByIDRequestValidator : AbstractValidator<GetUserByIDRequestViewModel>
    {
        public GetUserByIDRequestValidator()
        {
        }
    }
    public class GetUserByIDRequestProfile : Profile
    {
        public GetUserByIDRequestProfile()
        {
            CreateMap<GetUserByIDRequestViewModel, GetUserByIDQuery>();
        }
    }
}
