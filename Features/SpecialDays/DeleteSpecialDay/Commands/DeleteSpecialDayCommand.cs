using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.SpecialDays;

namespace EasyTask.Features.SpecialDays.DeleteSpecialDay.Commands
{
    public record DeleteSpecialDayCommand(string ID) : IRequestBase<bool>;
    public class DeleteSpecialDayCommandHandler : RequestHandlerBase<SpecialDay, DeleteSpecialDayCommand, bool>
    {
        public DeleteSpecialDayCommandHandler(RequestHandlerBaseParameters<SpecialDay> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteSpecialDayCommand request, CancellationToken cancellationToken)
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
