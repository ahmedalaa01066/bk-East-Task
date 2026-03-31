using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Managements.DeleteManagement.Commands
{
    public record DeleteManagementCommand(string ID) : IRequestBase<bool>;

    public class DeleteManagementCommandHandler : RequestHandlerBase<Management, DeleteManagementCommand, bool>
    {
        public DeleteManagementCommandHandler(RequestHandlerBaseParameters<Management> requestParameters) : base(requestParameters) { }

        public async override Task<RequestResult<bool>> Handle(DeleteManagementCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
         
            _repository.Delete(request.ID);
            _repository.SaveChanges();
            return await Task.FromResult(RequestResult<bool>.Success(true));
        }
    }

}
