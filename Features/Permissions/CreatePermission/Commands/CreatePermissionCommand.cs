using EasyTask.Common.Requests;
using EasyTask.Models.Permissions;

namespace EasyTask.Features.Permissions.CreatePermission.Commands
{
    public record CreatePermissionCommand(string Name, int MaxHours, int MinHours, int MaxRepeatTimes,
        int MaxHoursPerMonth) : IRequestBase<bool>;
    public class CreatePermissionCommandHandler : RequestHandlerBase<Permission, CreatePermissionCommand, bool>
    {
        public CreatePermissionCommandHandler(RequestHandlerBaseParameters<Permission> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            Permission permission = new Permission()
            {
                Name = request.Name,
                MaxHours = request.MaxHours,
                MinHours = request.MinHours,
                MaxRepeatTimes = request.MaxRepeatTimes,
                MaxHoursPerMonth = request.MaxHoursPerMonth
            };
            _repository.Add(permission);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
