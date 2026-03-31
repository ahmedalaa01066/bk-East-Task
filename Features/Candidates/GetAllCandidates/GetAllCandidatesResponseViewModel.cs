using AutoMapper;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Candidates.GetAllCandidates
{
    public class GetAllCandidatesResponseViewModel
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string Email { get; set; }
        public string JobCode { get; set; }
        public string PhoneNumber { get; set; }
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
    public class GetAllCandidatesResponseProfile : Profile
    {
        public GetAllCandidatesResponseProfile()
        {
            CreateMap<GetAllCandidatesDTO, GetAllCandidatesResponseViewModel>();
        }
    }
}
