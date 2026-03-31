using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.TaskDependencies;

namespace EasyTask.Features.Common.TaskDependencies.DTOs
{
    public record CreateTaskDependencyDTO(Dependencies DependencyType, string DestinationtaskId);
    public class CreateTaskDependencyDTOProfile : Profile
    {
        public CreateTaskDependencyDTOProfile()
        {
            CreateMap<TaskDependency, CreateTaskDependencyDTO>();
        }
    }
}
