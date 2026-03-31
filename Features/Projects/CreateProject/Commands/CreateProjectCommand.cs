using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.CreateProject.Commands
{
    public record CreateProjectCommand(
        string Name,
        bool Strategic,
        bool Financial,
        DateTime? KickOffDate,
        bool IsKickOffmeeting,
        DateTime StartDate,
        DateTime? EndDate,
        string? ProjectPurpose,
        string? Scope,
        string? Deliverables,
        string? HighLevelRequirements,
        string ProjectTypeId,
        string ProjectManagerId,
        string ProjectOwnerId,
        string ManagementId,
        string DepartmentId,
        ICollection<string>? ScrumMastersIds
    ) :IRequestBase<string>;
    public class CreateProjectCommandHandler : RequestHandlerBase<Project, CreateProjectCommand, string>
    {
        public CreateProjectCommandHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            //var listOfScrumMasters = new List<Candidate>();
            //if (request.ScrumMastersIds != null && request.ScrumMastersIds.Any())
            //{
            //    foreach (var id in request.ScrumMastersIds)
            //    {
            //        var scrumMasterDTO = await _mediator.Send(new GetCandidateModelByIdQuery(id));
            //        if (scrumMasterDTO != null)
            //        {
            //            listOfScrumMasters.Add(scrumMasterDTO.Data);
            //        }
            //    }
            //}

            Project project = request.MapOne<Project>();
            project.ProjectCode = GenerateGenericCode.Generate("PR-");
            //project.ScrumMasters = listOfScrumMasters;
            
            _repository.Add(project);
            _repository.SaveChanges();
            return RequestResult<string>.Success(project.ID);
        }
    }
}
