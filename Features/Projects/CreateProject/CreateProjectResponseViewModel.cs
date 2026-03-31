using AutoMapper;
using EasyTask.Features.Projects.CreateProject.Commands;

namespace EasyTask.Features.Projects.CreateProject
{
    public class CreateProjectResponseViewModel
    {
        public string ID { get; set; }
    }

    public class CreateProjectResponseProfile : Profile
    {
        public CreateProjectResponseProfile()
        {
            CreateMap<CreateProjectCommand, CreateProjectResponseViewModel>();
            CreateMap<string, CreateProjectResponseViewModel>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src));
        }
    }
}
