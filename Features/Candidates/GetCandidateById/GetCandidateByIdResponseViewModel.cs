using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.SetCandidateById
{
    public record GetCandidateByIdResponseViewModel
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string Email { get; set; }
        public string? Bio { get; set; }
        public string PhoneNumber { get; set; }
        public CandidateStatus CandidateStatus { get; set; }
        public string? ManagerId { get; set; }
        public string? ManagementId { get; set; }
        public string? DepartmentId { get; set; }
        public string LevelId { get; set; }
        public string LevelName { get; set; }
        public string PositionId { get; set; }
        public string? PositionName { get; set; }
        public string JobId { get; set; }
        public string? JobName { get; set; }
        public string? CandidateImage { get; set; }
        public List<string>? Paths { get; set; }

        public string? DocumentId { get; set; }
        public string? DocumentPath { get; set; }
        public Role RoleId { get; set; }
    }
    public class GetCandidateByIdResponseProfile:Profile
    {
        public GetCandidateByIdResponseProfile()
        {
            CreateMap<GetCandidateByIdDTO, GetCandidateByIdResponseViewModel>();
        }
    }
}
