using EasyTask.Common.Requests;
using EasyTask.Models.Enums;
using EasyTask.Models.KPIs;

namespace EasyTask.Features.KPIs.CreateKPI.Commands
{
    public record CreateKPICommand(string Name, KPIType Type) : IRequestBase<string>;
    public class CreateKPICommandHandler : RequestHandlerBase<KPI, CreateKPICommand, string>
    {
        public CreateKPICommandHandler(RequestHandlerBaseParameters<KPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateKPICommand request, CancellationToken cancellationToken)
        {
            KPI kpi = new KPI
            {
                Name = request.Name,
                Type = request.Type
            };
            _repository.Add(kpi);
            _repository.SaveChanges();
            return RequestResult<string>.Success(kpi.ID);
        }
    }
}
