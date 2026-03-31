using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.SetCandidateById
{
    public record GetCandidateByIdRequestViewModel(string ID);
    public class GetCandidateByIdRequestValidator:AbstractValidator<GetCandidateByIdRequestViewModel>
    {
        public GetCandidateByIdRequestValidator() { }
    }
    public class GetCandidateByIdRequestProfile : Profile
    {
        public GetCandidateByIdRequestProfile()
        {
            CreateMap<GetCandidateByIdRequestViewModel, GetCandidateByIdQuery>();
        }
    }
}
