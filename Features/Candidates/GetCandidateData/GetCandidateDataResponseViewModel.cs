using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.GetCandidateData
{
    public record GetCandidateDataResponseViewModel
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
    public class GetCandidateDataResponseProfile:Profile
    {
        public GetCandidateDataResponseProfile()
        {
            CreateMap<GetCandidateDataDTO, GetCandidateDataResponseViewModel>();
        }
    }
}
