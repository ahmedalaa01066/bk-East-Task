using EasyTask.Common.Requests;
using EasyTask.Models.Penalities;

namespace EasyTask.Features.Penalities.AddPenality.Command
{
    public record AddPenalityCommand(string Description,string CandidateId) : IRequestBase<string>;
    public class AddPenalityCommandHandler : RequestHandlerBase<Penality, AddPenalityCommand, string>
    {
        public AddPenalityCommandHandler(RequestHandlerBaseParameters<Penality> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(AddPenalityCommand request, CancellationToken cancellationToken)
        {
            Penality model = new Penality()
            {
                Description = request.Description,
                CandidateId = request.CandidateId,
            };
            _repository.Add(model);
            _repository.SaveChanges();
            return RequestResult<string>.Success(model.ID);
        }
    }
}
