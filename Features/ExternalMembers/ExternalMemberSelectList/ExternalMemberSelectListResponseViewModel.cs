using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.ExternalMembers.ExternalMemberSelectList
{
    public record ExternalMemberSelectListResponseViewModel(string ID,string Name);
    public class ExternalMemberSelectListResponseProfile : Profile
    {
        public ExternalMemberSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, ExternalMemberSelectListResponseViewModel>();
        }
    }
}
