using AutoMapper;
using EasyTask.Features.Common.Vacations.Queries;
using FluentValidation;

namespace EasyTask.Features.Vacations.GetAllVacations
{
    public record GetAllVacationsRequestViewModel(string? Name, int pageIndex = 1, int pageSize = 100);
    public class GetAllVacationsRequestValidator : AbstractValidator<GetAllVacationsRequestViewModel>
    {
        public GetAllVacationsRequestValidator()
        {
        }
    }
    public class GetAllVacationsRequestProfile : Profile
    {
        public GetAllVacationsRequestProfile()
        {
            CreateMap<GetAllVacationsRequestViewModel, GetAllVacationsQuery>();
        }
    }
}
