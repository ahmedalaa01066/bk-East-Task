using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;
using FluentValidation;

namespace EasyTask.Features.Candidates.GetManagerByCandidateId
{
    public record GetManagerByCandidateIdRequestViewModel(string ID);
    public class GetManagerByCandidateIdRequestValidator : AbstractValidator<GetManagerByCandidateIdRequestViewModel>
    {
        public GetManagerByCandidateIdRequestValidator()
        {
        }
    }
    public class GetManagerByCandidateIdRequestProfile : Profile
    {
        public GetManagerByCandidateIdRequestProfile()
        {
            CreateMap<GetManagerByCandidateIdRequestViewModel, GetManagerByCandidateIdQuery>();
        }
    }
}
