using EasyTask.Common.Requests;
using EasyTask.Models.ExternalComapnies;

namespace EasyTask.Features.ExternalCompanies.CreateExternalCompany.Commands
{
    public record CreateExternalCompanyCommand(string Name, string? Location) : IRequestBase<bool>;
    public class CreateExternalCompanyCommandHandler : RequestHandlerBase<ExternalCompany, CreateExternalCompanyCommand, bool>
    {
        public CreateExternalCompanyCommandHandler(RequestHandlerBaseParameters<ExternalCompany> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateExternalCompanyCommand request, CancellationToken cancellationToken)
        {
            ExternalCompany ExternalCompany = new ExternalCompany { Name = request.Name , Location = request.Location };
            _repository.Add(ExternalCompany);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
