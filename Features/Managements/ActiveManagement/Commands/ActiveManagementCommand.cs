using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Managements.ActiveManagement.Commands
{
    public record ActiveManagementCommand(string ID) : IRequestBase<bool>;
    public class ActiveManagementCommandHandler : RequestHandlerBase<Management, ActiveManagementCommand, bool>
    {
        public ActiveManagementCommandHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(ActiveManagementCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Management Management = new Management { ID = request.ID };
            Management.IsActive = true;
            _repository.SaveIncluded(Management, nameof(Management.IsActive));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
