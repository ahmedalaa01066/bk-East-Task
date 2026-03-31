using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using AutoMapper;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class GetAllCandidatesDTO
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string JobCode { get; set; }
        public CandidateStatus CandidateStatus { get; set; }
        public string? Manager { get; set; }
        public string? Management { get; set; }
        public string? Department { get; set; }
        public string Level { get; set; }
        public string Position { get; set; }
        public string? PositionName { get; set; }
        public string JobId { get; set; }
        public string? JobName { get; set; }
        public string? CandidateImage { get; set; }
        public Role RoleId { get; set; }
    }
    public class GetAllCandidatesDTOProfile : Profile
    {
        public GetAllCandidatesDTOProfile()
        {
            CreateMap<Candidate, GetAllCandidatesDTO>()
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => string.Concat(src.Manager.FirstName, src.Manager.LastName)))
                .ForMember(dest => dest.Management, opt => opt.MapFrom(src => src.Management.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.Name))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.User.RoleId))
                .ForMember(dest => dest.JobName, opt => opt.MapFrom(src => src.Job != null ? src.Job.Name : null))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name));
        }
    }
}
