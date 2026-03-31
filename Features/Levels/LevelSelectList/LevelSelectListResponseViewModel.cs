using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Levels.LevelSelectList
{
    public record LevelSelectListResponseViewModel(string Name, string ID);
    public class LevelSelectListResponseProfile : Profile
    {
        public LevelSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, LevelSelectListResponseViewModel>();
        }
    }
}
