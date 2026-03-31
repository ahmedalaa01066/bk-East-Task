using AutoMapper;
using EasyTask.Features.Common.Candidates.Queries;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public record ExportCandidatesDTO(byte[] FileContent, string FileName, string ContentType);
    public class ExportCandidatesProfile : Profile
    {
        public ExportCandidatesProfile()
        {
            CreateMap<ExportCandidatesQuery, GetAllCandidatesQuery>();
        }
    }
}
