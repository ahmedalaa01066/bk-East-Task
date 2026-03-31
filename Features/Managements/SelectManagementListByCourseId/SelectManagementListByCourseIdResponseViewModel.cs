using AutoMapper;
using EasyTask.Features.Common.Managements.DTOs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Managements.SelectManagementListByCourseId
{
    public record SelectManagementListByCourseIdResponseViewModel
    (string ID, string Name, Assignment Assignment);
    public class SelectManagementListByCourseIdResponseProfile : Profile
    {
        public SelectManagementListByCourseIdResponseProfile()
        {
            CreateMap<SelectManagementListByCourseIdDTO, SelectManagementListByCourseIdResponseViewModel>();
        }
    }
}
