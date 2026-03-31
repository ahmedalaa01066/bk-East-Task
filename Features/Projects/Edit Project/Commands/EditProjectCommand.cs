using EasyTask.Common.Requests;
using EasyTask.Models.Projects;

namespace EasyTask.Features.Projects.Edit_Project.Commands
{
    public record EditProjectCommand(
        string ID,
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
    ) : IRequestBase<bool>;
    public class EditProjectCommandHandler : RequestHandlerBase<Project, EditProjectCommand, bool>
    {
        public EditProjectCommandHandler(RequestHandlerBaseParameters<Project> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                ID = request.ID,
                Name = request.Name,
                Strategic = request.Strategic,
                Financial = request.Financial,
                KickOffDate = request.KickOffDate,
                IsKickOffmeeting = request.IsKickOffmeeting,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ProjectPurpose = request.ProjectPurpose,
                Scope = request.Scope,
                Deliverables = request.Deliverables,
                HighLevelRequirements = request.HighLevelRequirements,
                ProjectTypeId = request.ProjectTypeId,
                ProjectManagerId = request.ProjectManagerId,
                ProjectOwnerId = request.ProjectOwnerId,
                ManagementId = request.ManagementId,
                DepartmentId = request.DepartmentId
            };

            // Track which scalar properties are being updated
            _repository.SaveIncluded(
                project,
                nameof(project.Name),
                nameof(project.Strategic),
                nameof(project.Financial),
                nameof(project.KickOffDate),
                nameof(project.IsKickOffmeeting),
                nameof(project.StartDate),
                nameof(project.EndDate),
                nameof(project.ProjectPurpose),
                nameof(project.Scope),
                nameof(project.Deliverables),
                nameof(project.HighLevelRequirements),
                nameof(project.ProjectTypeId),
                nameof(project.ProjectManagerId),
                nameof(project.ProjectOwnerId),
                nameof(project.ManagementId),
                nameof(project.DepartmentId)
            );

            //// Handle ScrumMasters (Many-to-many)
            //if (request.ScrumMastersIds is not null)
            //{
            //    var existingProject = await _repository.DbSet
            //        .Include(p => p.ScrumMasters)
            //        .FirstOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            //    if (existingProject == null)
            //        return RequestResult<bool>.Fail("Project not found");

            //    // Replace old items
            //    existingProject.ScrumMasters.Clear();

            //    foreach (var scrumMasterId in request.ScrumMastersIds)
            //    {
            //        existingProject.ScrumMasters.Add(new ProjectScrumMaster
            //        {
            //            ProjectId = request.ID,
            //            ScrumMasterId = scrumMasterId
            //        });
            //    }
            //}

            _repository.SaveChanges();
            return RequestResult<bool>.Success(true);
        }
    }
}
