using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;

namespace EasyTask.Features.Candidates.CreateCandidate
{
    public record CreateCandidateResponseViewModel(string ID, string? Path, string? DocumentId);
    public class CreateCandidateResponseProfile : Profile
    {
        public CreateCandidateResponseProfile()
        {
            CreateMap<CreateCandidateDTO, CreateCandidateResponseViewModel>();
        }
    }
}
