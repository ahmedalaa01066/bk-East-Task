using AutoMapper;
using EasyTask.Models.Enums;
using EasyTask.Models.WorkPackageDependencies;

namespace EasyTask.Features.Common.WorkPackageDependencies.DTO
{
    public record CreateWorkPackageDependencyDTO(Dependencies DependencyType, string DestinationWorkPackageId);
    public class CreateWorkPackageDependencyDTOProfile : Profile
    {
        public CreateWorkPackageDependencyDTOProfile()
        {
            CreateMap<WorkPackageDependency, CreateWorkPackageDependencyDTO>();
        }
    }
}
