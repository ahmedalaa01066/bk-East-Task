using AutoMapper;
using EasyTask.Features.Common.Courses.DTOs;

namespace EasyTask.Features.Courses.GetAllCouesesWithCandidateNumber
{
    public record GetAllCouesesWithCandidateNumberResponseViewModel
    (string ID, string Name, int NumOfCandidates);
    public class GetAllCouesesWithCandidateNumberResponseProfile : Profile
    {
        public GetAllCouesesWithCandidateNumberResponseProfile()
        {
            CreateMap<GetAllCouesesWithCandidateNumberDTO, GetAllCouesesWithCandidateNumberResponseViewModel>();
        }
    }
}
