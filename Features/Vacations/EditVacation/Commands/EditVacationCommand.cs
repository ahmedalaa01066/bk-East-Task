using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Vacations;

namespace EasyTask.Features.Vacations.EditVacation.Commands
{
    public record EditVacationCommand(string ID,string Name ,int MaxRequestNum , int ConfirmationLayerNum ) : IRequestBase<bool>;
    public class EditVacationCommandHandler : RequestHandlerBase<Vacation, EditVacationCommand, bool>
    {
        public EditVacationCommandHandler(RequestHandlerBaseParameters<Vacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditVacationCommand request, CancellationToken cancellationToken)
        {
            Vacation vacation = await _repository.GetByIDAsync(request.ID);
            if (vacation == null)
            {
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            }
            vacation.Name = request.Name;
            vacation.MaxRequestNum = request.MaxRequestNum;
            vacation.ConfirmationLayerNum = request.ConfirmationLayerNum;

            _repository.SaveIncluded(vacation , nameof(vacation.Name), nameof(vacation.MaxRequestNum), nameof(vacation.ConfirmationLayerNum));
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
