using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.ProjectTypes;

namespace EasyTask.Features.ProjectTypes.CreateProjectType.Commands
{
    public record CreateProjectTypeCommand(string Name):IRequestBase<bool>;
    public class CreateProjectTypeCommandHandler : RequestHandlerBase<ProjectType, CreateProjectTypeCommand, bool>
    {
        public CreateProjectTypeCommandHandler(RequestHandlerBaseParameters<ProjectType> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CreateProjectTypeCommand request, CancellationToken cancellationToken)
        {
            ProjectType ProjectType = new ProjectType { Name = request.Name};
            
            _repository.Add(ProjectType);
            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
