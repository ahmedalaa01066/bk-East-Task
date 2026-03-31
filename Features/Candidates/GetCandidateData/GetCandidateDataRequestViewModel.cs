using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.GetCandidateData
{
    public record GetCandidateDataRequestViewModel(string CandidateId);
    public class GetCandidateDataRequestValidator:AbstractValidator<GetCandidateDataRequestViewModel>
    {
        public GetCandidateDataRequestValidator() { }
    }
    public class GetCandidateDataRequestProfile : Profile
    {
        public GetCandidateDataRequestProfile()
        {
            CreateMap<GetCandidateDataRequestViewModel, GetCandidateDataQuery>();
        }
    }
}
