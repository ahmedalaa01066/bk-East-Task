using AutoMapper;
using EasyTask.Features.Common.VacationRequests.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.GetAllVacationRequests
{
    public record GetAllVacationRequestsRequestViewModel(bool? IsSpecial,RequestStatus? VacationRequestStatus, int pageIndex = 1,
        int pageSize = 100);
    public class GetAllVacationRequestsRequestValidator : AbstractValidator<GetAllVacationRequestsRequestViewModel>
    {
        public GetAllVacationRequestsRequestValidator()
        {
        }
    }
    public class GetAllVacationRequestsRequestProfile : Profile
    {
        public GetAllVacationRequestsRequestProfile()
        {
            CreateMap<GetAllVacationRequestsRequestViewModel, GetAllVacationRequestsQuery>();
        }
    }
}
