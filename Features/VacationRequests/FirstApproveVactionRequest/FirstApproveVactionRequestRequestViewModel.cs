using AutoMapper;
using EasyTask.Features.VacationRequests.FirstApproveVactionRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.VacationRequests.FirstApproveVactionRequest
{
    public record FirstApproveVactionRequestRequestViewModel(string ID);
    public class FirstApproveVactionRequestRequestValidator : AbstractValidator<FirstApproveVactionRequestRequestViewModel>
    {
        public FirstApproveVactionRequestRequestValidator()
        {
        }
    }
    public class FirstApproveVactionRequestRequestProfile : Profile
    {
        public FirstApproveVactionRequestRequestProfile()
        {
            CreateMap<FirstApproveVactionRequestRequestViewModel, FirstApproveVactionRequestCommand>();
        }
    }
}
