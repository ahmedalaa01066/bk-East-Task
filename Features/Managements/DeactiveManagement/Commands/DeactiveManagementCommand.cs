using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Managements.DeactiveManagement.Commands
{
    public record DeactiveManagementCommand(string ID) : IRequestBase<bool>;
    public class DeactiveManagementCommandHandler : RequestHandlerBase<Management, DeactiveManagementCommand, bool>
    {
        public DeactiveManagementCommandHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeactiveManagementCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            Management Management = new Management { ID = request.ID };
            Management.IsActive = false;
            _repository.SaveIncluded(Management, nameof(Management.IsActive));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
