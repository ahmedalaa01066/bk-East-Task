using AutoMapper;
using EasyTask.Features.PermissionRequests.CreatePermissionRequest.Commands;
using FluentValidation;

namespace EasyTask.Features.PermissionRequests.CreatePermissionRequest
{
    public record CreatePermissionRequestRequestViewModel(string? CandidateId, string PermissionId, DateOnly Date,
        TimeSpan FromTime, TimeSpan ToTime);
    public class CreatePermissionRequestRequestValidator : AbstractValidator<CreatePermissionRequestRequestViewModel>
    {
        public CreatePermissionRequestRequestValidator()
        {
        }
    }
    public class CreatePermissionRequestRequestProfile : Profile
    {
        public CreatePermissionRequestRequestProfile()
        {
            CreateMap<CreatePermissionRequestRequestViewModel, CreatePermissionRequestCommand>();
        }
    }
}
