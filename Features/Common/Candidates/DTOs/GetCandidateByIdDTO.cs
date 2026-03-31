using AutoMapper;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public record GetCandidateByIdDTO
    {
        public string ID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string Email { get; set; }
        public string? Bio {  get; set; }
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
        public string? DocumentId {  get; set; }
        public string? DocumentPath {  get; set; }
        public Role RoleId { get; set; }
    }
    public class GetCandidateByIdDTOProfile : Profile
    {
        public GetCandidateByIdDTOProfile()
        {
            CreateMap<Candidate, GetCandidateByIdDTO>()
                .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Level != null ? src.Level.Name : null))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.User.RoleId))
                .ForMember(dest => dest.JobName, opt => opt.MapFrom(src => src.Job != null ? src.Job.Name : null));
        }
    }
}
