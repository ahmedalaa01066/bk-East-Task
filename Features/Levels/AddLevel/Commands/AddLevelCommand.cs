using EasyTask.Common.Requests;
using EasyTask.Models.Levels;

namespace EasyTask.Features.Levels.AddLevel.Commands
{
    public record AddLevelCommand(string Name, int Sequence) :IRequestBase<bool>;
    public class AddLevelCommandHandler : RequestHandlerBase<Level, AddLevelCommand, bool>
    {
        public AddLevelCommandHandler(RequestHandlerBaseParameters<Level> requestParameters) : base(requestParameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(AddLevelCommand request, CancellationToken cancellationToken)
        {
            Level Level=new Level { Name = request.Name , Sequence = request.Sequence};
            _repository.Add(Level);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
