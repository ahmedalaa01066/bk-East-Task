using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.DefaultKPIs;

namespace EasyTask.Features.DefaultKPIs.DeleteDefaultKPI.Commands
{
    public record DeleteDefaultKPICommand(string ID):IRequestBase<bool>;
    public class DeleteDefaultKPICommandHandler : RequestHandlerBase<DefaultKPI, DeleteDefaultKPICommand, bool>
    {
        public DeleteDefaultKPICommandHandler(RequestHandlerBaseParameters<DefaultKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteDefaultKPICommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            _repository.Delete(request.ID);
            _repository.SaveChanges();
            return await Task.FromResult(RequestResult<bool>.Success(true));
        }
    }
    
}
