using AutoMapper;
using EasyTask.Common.Views;

namespace EasyTask.Features.Jobs.JobSelectList
{
    public record JobSelectListResponseViewModel(string Name, string ID);
    public class JobSelectListResponseProfile : Profile
    {
        public JobSelectListResponseProfile()
        {
            CreateMap<SelectListItemViewModel, JobSelectListResponseViewModel>();
        }
    }
}
