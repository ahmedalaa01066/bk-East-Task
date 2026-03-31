using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Positions.PositionSelectList
{
    public record PositionSelectListResponseViewModel(string Name, string ID);
    public class PositionSelectListResponseProfile:Profile
    {
        public PositionSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, PositionSelectListResponseViewModel>();
        }
    }
}
