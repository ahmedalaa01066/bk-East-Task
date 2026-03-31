using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Features.Common.Vacations.Queries;
using EasyTask.Models.CandidateVacations;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.CandidateVacations.DeductCandidateVacationsDay.Command
{
    public record DeductCandidateVacationsDayCommand(string CandidateId, string VacationId,int NumberOfDays):IRequestBase<bool>;
    public class DeductCandidateVacationsDayCommandHandler : RequestHandlerBase<CandidateVacation, DeductCandidateVacationsDayCommand, bool>
    {
        public DeductCandidateVacationsDayCommandHandler(RequestHandlerBaseParameters<CandidateVacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeductCandidateVacationsDayCommand request, CancellationToken cancellationToken)
        {
            var currentYear = DateTime.UtcNow.Year;
            var candidateVacation = await _repository
                .Get(cv => cv.CandidateId == request.CandidateId && cv.VacationId == request.VacationId && cv.Year == currentYear)
                .FirstOrDefaultAsync(cancellationToken);

            if (candidateVacation == null)
            {
                var vacation = await _mediator.Send(new GetVacationByIdQuery(request.VacationId), cancellationToken);
                if (!vacation.IsSuccess)
                {
                    return RequestResult<bool>.Failure(vacation.ErrorCode);
                }

                var maxRequestNum = vacation.Data.MaxRequestNum;

                if (request.NumberOfDays > maxRequestNum)
                {
                    return RequestResult<bool>.Failure(ErrorCode.NotEnoughVacationDays, "Not enough vacation days available.");
                }

                candidateVacation = new CandidateVacation
                {
                    CandidateId = request.CandidateId,
                    VacationId = request.VacationId,
                    Counter = maxRequestNum - request.NumberOfDays,
                    Year= currentYear
                };

                 _repository.Add(candidateVacation);
                _repository.SaveChanges();

                return RequestResult<bool>.Success(true);
            }

            if (candidateVacation.Counter < request.NumberOfDays)
            {
                return RequestResult<bool>.Failure(ErrorCode.NotEnoughVacationDays, "Not enough vacation days available.");
            }

            candidateVacation.Counter -= request.NumberOfDays;

            _repository.SaveIncluded(candidateVacation, nameof(candidateVacation.Counter));
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }

    }
}
