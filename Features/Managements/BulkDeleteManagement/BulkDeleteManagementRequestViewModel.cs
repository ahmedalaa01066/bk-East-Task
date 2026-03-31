using AutoMapper;
using FluentValidation;
using EasyTask.Features.Managements.BulkDeleteManagement.Orchisterator;

namespace EasyTask.Features.Managements.BulkDeleteManagement
{
    public record BulkDeleteManagementRequestViewModel(List<string> Ids);

    public class BulkDeleteManagementRequestValidator : AbstractValidator<BulkDeleteManagementRequestViewModel>
    {
        public BulkDeleteManagementRequestValidator()
        {
        }
    }
    public class BulkDeleteManagementRequestProfile : Profile
    {
        public BulkDeleteManagementRequestProfile()
        {
            CreateMap<BulkDeleteManagementRequestViewModel, BulkDeleteManagementOrchisterator>();
        }
    }
}
