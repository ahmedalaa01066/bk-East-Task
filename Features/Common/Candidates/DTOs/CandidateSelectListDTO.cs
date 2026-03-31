using AutoMapper;
using EasyTask.Models.Candidates;

namespace EasyTask.Features.Common.Candidates.DTOs
{
    public class CandidateSelectListDTO { 
        public string ID { get; set; }
        public string Name { get; set; }
           };
    public class CandidateSelectListDTOProfile : Profile
    {
        public CandidateSelectListDTOProfile()
        {
            CreateMap<Candidate, CandidateSelectListDTO>()
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName}  {src.LastName}"));
        }
    }
}
