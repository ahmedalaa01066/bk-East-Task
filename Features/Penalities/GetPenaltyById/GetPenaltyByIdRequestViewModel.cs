using AutoMapper;
using EasyTask.Features.Common.Penalities.Queries;
using FluentValidation;

namespace EasyTask.Features.Penalities.GetPenaltyById
{
    public record GetPenaltyByIdRequestViewModel(string ID);
    public class GetPenaltyByIdRequestValidator : AbstractValidator<GetPenaltyByIdRequestViewModel>
    {
        public GetPenaltyByIdRequestValidator()
        {
        }
    }
    public class GetPenaltyByIdRequestProfile : Profile
    {
        public GetPenaltyByIdRequestProfile() {
            CreateMap<GetPenaltyByIdRequestViewModel, GetPenaltyByIdQuery>();
        }
    }
}
