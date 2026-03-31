using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Models.SpecialDays;

namespace EasyTask.Features.SpecialDays.EditSpecialDay.Commands
{
    public record EditSpecialDayCommand(string ID, string Name, DateOnly FromDate, DateOnly? ToDate,
        bool IsOneDay) : IRequestBase<bool>;
    public class EditSpecialDayCommandHandler : RequestHandlerBase<SpecialDay, EditSpecialDayCommand, bool>
    {
        public EditSpecialDayCommandHandler(RequestHandlerBaseParameters<SpecialDay> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditSpecialDayCommand request, CancellationToken cancellationToken)
        {
            var check = await _repository.AnyAsync(b => b.ID == request.ID);
            if (!check)
                return RequestResult<bool>.Failure(ErrorCode.NotFound);
            SpecialDay SpecialDay = new SpecialDay { ID = request.ID };
            SpecialDay.Name = request.Name;
            SpecialDay.FromDate = request.FromDate;
            SpecialDay.ToDate = request.ToDate;
            SpecialDay.IsOneDay = request.IsOneDay;
            _repository.SaveIncluded(SpecialDay, nameof(SpecialDay.Name), nameof(SpecialDay.FromDate),
                nameof(SpecialDay.ToDate), nameof(SpecialDay.IsOneDay));
            _repository.SaveChanges();
            var result = RequestResult<bool>.Success(true);
            return await Task.FromResult(result);
        }
    }
}
