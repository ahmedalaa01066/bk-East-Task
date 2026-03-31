using AutoMapper;
using EasyTask.Features.Common.Courses.Queries;
using FluentValidation;

namespace EasyTask.Features.Courses.GetAllCouesesWithCandidateNumber
{
    public record GetAllCouesesWithCandidateNumberRequestViewModel
    (
        string? Name,
        DateTime? From,
        DateTime? To,
        int pageIndex = 1,
        int pageSize = 100
        );
    public class GetAllCouesesWithCandidateNumberRequestValidator : AbstractValidator<GetAllCouesesWithCandidateNumberRequestViewModel>
    {
        public GetAllCouesesWithCandidateNumberRequestValidator()
        {
        }
    }
    public class GetAllCouesesWithCandidateNumberRequestProfile : Profile
    {
        public GetAllCouesesWithCandidateNumberRequestProfile()
        {
            CreateMap<GetAllCouesesWithCandidateNumberRequestViewModel, GetAllCouesesWithCandidateNumberQuery>();
        }
    }
}
