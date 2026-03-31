using EasyTask.Common.Requests;
using EasyTask.Models.DefaultKPIs;
using EasyTask.Models.Enums;

namespace EasyTask.Features.DefaultKPIs.CreateDefaultKPI.Commands
{
    public record CreateDefaultKPICommand(string Name, KPIType Type, double Percentage) : IRequestBase<string>;
    public class CreateDefaultKPICommandHandler : RequestHandlerBase<DefaultKPI, CreateDefaultKPICommand, string>
    {
        public CreateDefaultKPICommandHandler(RequestHandlerBaseParameters<DefaultKPI> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateDefaultKPICommand request, CancellationToken cancellationToken)
        {
            DefaultKPI defaultKPI = new DefaultKPI
            {
                Name = request.Name,
                Type = request.Type,
                Percentage = request.Percentage
            };
            _repository.Add(defaultKPI);
            _repository.SaveChanges();
            return RequestResult<string>.Success(defaultKPI.ID);
        }
    }
}
