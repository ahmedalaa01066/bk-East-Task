using EasyTask.Common.Requests;
using EasyTask.Common.Views;
using EasyTask.Features.Common.CandidateVacations.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.CandidateVacations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyTask.Features.Common.CandidateVacations.Queries
{
    public record GetAllCandidateVacationsQuery(string? SearchText, int pageIndex = 1,
        int pageSize = 100):IRequestBase<PagingViewModel<GetAllCandidateVacationsDTO>>;
    public class GetAllCandidateVacationsQueryHandler : RequestHandlerBase<CandidateVacation, GetAllCandidateVacationsQuery, PagingViewModel<GetAllCandidateVacationsDTO>>
    {
        public GetAllCandidateVacationsQueryHandler(RequestHandlerBaseParameters<CandidateVacation> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<PagingViewModel<GetAllCandidateVacationsDTO>>> Handle(GetAllCandidateVacationsQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<CandidateVacation>(true);

            predicate = predicate.And(c =>
                string.IsNullOrEmpty(request.SearchText) ||
                (c.Candidate.FirstName + " " + c.Candidate.LastName).Contains(request.SearchText) ||
                c.Vacation.Name.Contains(request.SearchText));

            var result = await _repository
                .Get(predicate)
                .Include(c => c.Candidate)
                .Include(c => c.Vacation).OrderByDescending(c => c.Year)
                .Map<GetAllCandidateVacationsDTO>()
                .ToPagesAsync(request.pageIndex, request.pageSize);

            return RequestResult<PagingViewModel<GetAllCandidateVacationsDTO>>.Success(result);
        }
    }
}
