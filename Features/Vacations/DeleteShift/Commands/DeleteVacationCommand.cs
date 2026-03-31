using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.Vacations;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Vacations.DeleteVacation.Commands
{
    public record DeleteVacationCommand(string ID):IRequestBase<bool>;
    public class DeleteVacationCommandHandler : RequestHandlerBase<Vacation, DeleteVacationCommand, bool>
    {
        public DeleteVacationCommandHandler(RequestHandlerBaseParameters<Vacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteVacationCommand request, CancellationToken cancellationToken)
        {
            var Vacation = await _repository
                  .Get(s => s.ID == request.ID)
                  .Include(s => s.VacationRequests) 
                  .FirstOrDefaultAsync();

            if (Vacation == null)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);

            if (Vacation.VacationRequests != null && Vacation.VacationRequests.Any())
                return RequestResult<bool>.Failure(ErrorCode.CannotDelete); 

            _repository.Delete(Vacation);
             _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
