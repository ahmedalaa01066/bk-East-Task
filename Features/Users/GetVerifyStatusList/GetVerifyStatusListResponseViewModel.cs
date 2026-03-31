using AutoMapper;
using EasyTask.Common.Views;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Users.GetVerifyStatusList
{
    public record GetVerifyStatusListResponseViewModel(string Name, string ID);

    public class GetVerifyStatusListResponseProfile : Profile
    {
        public GetVerifyStatusListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, GetVerifyStatusListResponseViewModel>();
        }
    }
    }
