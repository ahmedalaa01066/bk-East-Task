using AutoMapper;
using FluentValidation;
using EasyTask.Features.Users.GetVerifyStatusList.Queries;

namespace EasyTask.Features.Users.GetVerifyStatusList
{
    public record GetVerifyStatusListRequestViewModel();
    public class GetVerifyStatusListRequestValidator : AbstractValidator<GetVerifyStatusListRequestViewModel>
    {
        public GetVerifyStatusListRequestValidator()
        {
        }
    }
    public class GetVerifyStatusListRequestProfile : Profile
    {
        public GetVerifyStatusListRequestProfile() {
            CreateMap<GetVerifyStatusListRequestViewModel, GetVerifyStatusListQuery>();
        }
    }
}
