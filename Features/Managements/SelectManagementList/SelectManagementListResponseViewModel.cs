using AutoMapper;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Managements.DTOs;

namespace EasyTask.Features.Managements.SelectManagementList
{
    public record SelectManagementListResponseViewModel(string ID, string Name);
    public class SelectManagementListResponseProfile : Profile
    {
        public SelectManagementListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, SelectManagementListResponseViewModel>();
        }
    }

}
