using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Features.Common.Levels.DTOs;
using EasyTask.Features.Common.Medias.Queries;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using EasyTask.Models.Levels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record GetAllCandidatesQuery(
         string? SearchText,
         string? ManagementId,
         string? DepartmentId,
         string? LevelId,
         Role? RoleId,
         CandidateStatus? CandidateStatus,
         string? PositionId,
        int pageIndex = 1,
        int pageSize = 100
    ) : IRequestBase<PagingViewModel<GetAllCandidatesDTO>>;
    public class GetAllCandidatesQueryHandler : RequestHandlerBase<Candidate, GetAllCandidatesQuery, PagingViewModel<GetAllCandidatesDTO>>
    {
        public GetAllCandidatesQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<RequestResult<PagingViewModel<GetAllCandidatesDTO>>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Candidate>(true);

            predicate = predicate
                .And(c => string.IsNullOrEmpty(request.SearchText) ||
                c.FirstName.Contains(request.SearchText) ||
                c.LastName.Contains(request.SearchText) ||
                c.Email.Contains(request.SearchText) ||
                c.JobCode.Contains(request.SearchText) ||
                c.PhoneNumber.Contains(request.SearchText))
                .And(c => string.IsNullOrEmpty(request.ManagementId) || c.ManagementId.Contains(request.ManagementId))
                .And(c => string.IsNullOrEmpty(request.DepartmentId) || c.DepartmentId.Contains(request.DepartmentId))
                .And(c => string.IsNullOrEmpty(request.LevelId) || c.LevelId.Contains(request.LevelId))
                .And(c => string.IsNullOrEmpty(request.PositionId) || c.PositionId.Contains(request.PositionId))
                .And(p => !request.CandidateStatus.HasValue || p.CandidateStatus == request.CandidateStatus.Value)
                .And(p => !request.RoleId.HasValue || p.User.RoleId == request.RoleId.Value);

            var model = await _repository
                .Get(predicate)
                .Include(c => c.Department)
                .Include(c => c.Management)
                .Include(c => c.Level)
                .Include(c => c.Manager)
                .Include(c => c.Position)
                .Include(c => c.Job)
                .Include(c => c.User)
                .Map<GetAllCandidatesDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            foreach (var item in model.Items)
            {
                var mediaResult = await _mediator.Send(new GetMediaForAnySourceQuery(item.ID, SourceType.CandidateImage));
                item.CandidateImage = mediaResult.Data;
            }

            return RequestResult<PagingViewModel<GetAllCandidatesDTO>>.Success(model);
        }
    }
}
