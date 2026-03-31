using AutoMapper;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public record GetCandidateDataDTO
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PositionId { get; set; }
        public string? PositionName { get; set; }
        public string JobId { get; set; }
        public string? JobName { get; set; }
        public string? CandidateImage { get; set; }
        public Role RoleId { get; set; }
    }
    public class GetCandidateDataDTOProfile : Profile
    {
        public GetCandidateDataDTOProfile()
        {
            CreateMap<Candidate, GetCandidateDataDTO>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.User.RoleId))
                .ForMember(dest => dest.JobName, opt => opt.MapFrom(src => src.Job != null ? src.Job.Name : null));
        }
    }
}
