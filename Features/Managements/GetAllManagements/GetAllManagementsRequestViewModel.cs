using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.Managements.Queries;

namespace EasyTask.Features.Managements.GetManagementByName
{
    public record GetAllManagementsRequestViewModel(string? Name, int pageIndex = 1,
        int pageSize = 100);

    public class GetManagementByNameRequestValidator : AbstractValidator<GetAllManagementsRequestViewModel>
    {
        public GetManagementByNameRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
        }
    }

    public class GetManagementByNameRequestProfile : Profile
    {
        public GetManagementByNameRequestProfile()
        {
            CreateMap<GetAllManagementsRequestViewModel, GetAllManagementsQuery>();
        }
    }
}
