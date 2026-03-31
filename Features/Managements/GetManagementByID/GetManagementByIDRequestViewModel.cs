using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Managements.Queries;

namespace EasyTask.Features.Managements.GetManagementByID
{
    public record GetManagementByIDRequestViewModel(string ID);
    public class GetManagementByIDRequestValidator:AbstractValidator<GetManagementByIDRequestViewModel>
    {
        public GetManagementByIDRequestValidator()
        { }
    }
    public class GetManagementByIDRequestProfile:Profile
    {
        public GetManagementByIDRequestProfile()
        {
            CreateMap<GetManagementByIDRequestViewModel, GetManagementByIDQuery>();
        }
    }

}
