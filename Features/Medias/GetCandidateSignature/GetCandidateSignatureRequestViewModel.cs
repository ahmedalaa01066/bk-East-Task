using AutoMapper;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Levels.GetCandidateSignature
{
    public record GetCandidateSignatureRequestViewModel(string SourceId, SourceType SourceType = SourceType.CandidateSignature);
    public class GetCandidateSignatureRequestValidator : AbstractValidator<GetCandidateSignatureRequestViewModel>
    {
        public GetCandidateSignatureRequestValidator()
        {
        }
    }
    public class GetCandidateSignatureRequestProfile : Profile
    {
        public GetCandidateSignatureRequestProfile() {
            CreateMap<GetCandidateSignatureRequestViewModel, GetMediaForAnySourceQuery>();
        }
    }
}
