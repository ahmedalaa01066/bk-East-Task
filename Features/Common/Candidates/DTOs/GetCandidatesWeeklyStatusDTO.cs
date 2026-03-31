using AutoMapper;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class GetCandidatesWeeklyStatusDTO
    {
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string DepartmentName { get; set; }
        public List<WeeklyStatusEntryDTO> WeeklyStatuses { get; set; } = new();
    }

    public class GetCandidatesWeeklyStatusDTOProfile : Profile
    {
        public GetCandidatesWeeklyStatusDTOProfile()
        {
            CreateMap<Candidate, GetCandidatesWeeklyStatusDTO>()
                .ForMember(dest => dest.CandidateId, opt => opt.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : "N/A"))
                .ForMember(dest => dest.WeeklyStatuses, opt => opt.Ignore());
        }
    }
}
