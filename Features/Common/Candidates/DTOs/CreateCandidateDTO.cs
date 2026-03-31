using AutoMapper;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public record CreateCandidateDTO(string ID,string? Path, string? DocumentId);
    public class CreateCandidateDTOProfile : Profile
    {
        public CreateCandidateDTOProfile()
        {
            CreateMap<Candidate, CreateCandidateDTO>();
        }
    }
}
