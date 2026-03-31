using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.GetCandidatesWeeklyStatus
{
    public class GetCandidatesWeeklyStatusResponseViewModel
    {
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string DepartmentName { get; set; }
        public List<WeeklyStatusEntryDTO> WeeklyStatuses { get; set; } = new();
    }
    public class GetCandidatesWeeklyStatusResponseProfile : Profile
    {
        public GetCandidatesWeeklyStatusResponseProfile()
        {
            CreateMap<GetCandidatesWeeklyStatusDTO, GetCandidatesWeeklyStatusResponseViewModel>();
        }
    }
}
