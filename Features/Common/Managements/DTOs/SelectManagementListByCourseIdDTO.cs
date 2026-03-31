using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Common.Managements.DTOs
{
    public class SelectManagementListByCourseIdDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Assignment Assignment { get; set; }
    }
    public class SelectManagementListByCourseIdDTOProfile : Profile
    {
        public SelectManagementListByCourseIdDTOProfile()
        {
            CreateMap<Management, SelectManagementListByCourseIdDTO>();
        }
    }
}
