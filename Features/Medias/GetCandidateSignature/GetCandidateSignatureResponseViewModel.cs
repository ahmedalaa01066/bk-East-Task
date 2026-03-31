using AutoMapper;

namespace EasyTask.Features.Levels.GetCandidateSignature
{
    public record GetCandidateSignatureResponseViewModel(string Path);
    public class GetCandidateSignatureResponseProfile : Profile
    {
        public GetCandidateSignatureResponseProfile()
        {
            CreateMap<string, GetCandidateSignatureResponseViewModel>()
                .ForCtorParam("Path", opt => opt.MapFrom(src => src));
        }
    }
}
