using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;

namespace EasyTask.Features.Candidates.ExportCandidates
{
    public record ExportCandidatesResponseViewModel(byte[] FileContent, string FileName, string ContentType);
    public class ExportCandidatesResponseProfile : Profile
    {
        public ExportCandidatesResponseProfile()
        {
            CreateMap<ExportCandidatesDTO, ExportCandidatesResponseViewModel>();
        }
    }
}
