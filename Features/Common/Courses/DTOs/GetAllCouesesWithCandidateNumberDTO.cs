using AutoMapper;
using EasyTask.Models.Courses;

namespace EasyTask.Features.Common.Courses.DTOs
{
    public class GetAllCouesesWithCandidateNumberDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int NumOfCandidates { get; set; }
    }
    public class GetAllCouesesWithCandidateNumberDTOProfile : Profile
    {
        public GetAllCouesesWithCandidateNumberDTOProfile()
        {
            CreateMap<Course, GetAllCouesesWithCandidateNumberDTO>()
                .ForMember(dest => dest.NumOfCandidates, opt => opt.MapFrom(src => src.candidateCourses != null
                        ? src.candidateCourses.Count(cc => cc.Deleted == false) : 0));
        }
    }
}
