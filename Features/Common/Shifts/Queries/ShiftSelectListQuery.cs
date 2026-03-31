using EasyTask.Common.Requests;
using EasyTask.Features.Common.Shifts.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Shifts;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Features.Common.Shifts.Queries
{
    public record ShiftSelectListQuery : IRequestBase<IEnumerable<ShiftSelectListDTO>>;
    public class ShiftSelectListQueryHandler : RequestHandlerBase<Shift, ShiftSelectListQuery, IEnumerable<ShiftSelectListDTO>>
    {
        public ShiftSelectListQueryHandler(RequestHandlerBaseParameters<Shift> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<IEnumerable<ShiftSelectListDTO>>> Handle(ShiftSelectListQuery request, CancellationToken cancellationToken)
        {
            var selectListItems = await _repository.Get().Map<ShiftSelectListDTO>().ToListAsync();
            return RequestResult<IEnumerable<ShiftSelectListDTO>>.Success(selectListItems);
        }
    }
}
