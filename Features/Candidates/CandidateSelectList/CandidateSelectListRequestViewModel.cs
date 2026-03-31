using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.CandidateSelectList
{
    public record CandidateSelectListRequestViewModel();
    public class CandidateSelectListRequestValidator:AbstractValidator<CandidateSelectListRequestViewModel>
    {
        public CandidateSelectListRequestValidator() { }
    }
    public class CandidateSelectListRequestProfile:Profile
    {
        public CandidateSelectListRequestProfile()
        {
            CreateMap<CandidateSelectListRequestViewModel, CandidateSelectListQuery>();
        }
    }
}
