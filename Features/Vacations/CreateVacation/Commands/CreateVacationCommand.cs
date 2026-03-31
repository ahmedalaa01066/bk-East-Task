using EasyTask.Common.Requests;
using EasyTask.Models.Vacations;

namespace EasyTask.Features.Vacations.CreateVacation.Commands
{
    public record CreateVacationCommand(string Name ,int MaxRequestNum , int ConfirmationLayerNum ) : IRequestBase<bool>;
    public class CreateVacationCommandHandler : RequestHandlerBase<Vacation, CreateVacationCommand, bool>
    {
        public CreateVacationCommandHandler(RequestHandlerBaseParameters<Vacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateVacationCommand request, CancellationToken cancellationToken)
        {
            Vacation vacation = new Vacation()
            {
                Name = request.Name,
                MaxRequestNum = request.MaxRequestNum,
                ConfirmationLayerNum = request.ConfirmationLayerNum
            };
            _repository.Add( vacation );
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
