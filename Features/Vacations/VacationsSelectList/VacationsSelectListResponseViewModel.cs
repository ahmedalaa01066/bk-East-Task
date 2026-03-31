using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Vacations.VacationsSelectList
{
    public record VacationsSelectListResponseViewModel(string Name, string ID);
    public class VacationsSelectListResponseProfile : Profile
    {
        public VacationsSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, VacationsSelectListResponseViewModel>();
        }
    }
}
