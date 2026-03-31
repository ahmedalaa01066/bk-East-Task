using EasyTask.Common.Requests;
using EasyTask.Models.SpecialDays;

namespace EasyTask.Features.SpecialDays.AddSpecialDay.Command
{
    public record AddSpecialDayCommand(string Name, DateOnly FromDate, DateOnly? ToDate, bool IsOneDay) : IRequestBase<bool>;
    public class AddSpecialDayCommandHandler : RequestHandlerBase<SpecialDay, AddSpecialDayCommand, bool>
    {
        public AddSpecialDayCommandHandler(RequestHandlerBaseParameters<SpecialDay> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddSpecialDayCommand request, CancellationToken cancellationToken)
        {
            var specialDay = new SpecialDay
            {
                Name = request.Name,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                IsOneDay = request.IsOneDay,
            };

            await _repository.AddAsync(specialDay);
            _repository.SaveChanges();

            return RequestResult<bool>.Success(true);
        }
    }
}
