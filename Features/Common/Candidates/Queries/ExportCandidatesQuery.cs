using EasyTask.Common.Requests;
using EasyTask.Features.Common.Candidates.DTOs;
using EasyTask.Helpers;
using EasyTask.Models.Candidates;
using EasyTask.Models.Enums;
using OfficeOpenXml;

namespace EasyTask.Features.Common.Candidates.Queries
{
    public record ExportCandidatesQuery(
         string? SearchText,
         string? ManagementId,
         string? DepartmentId,
         string? LevelId,
         CandidateStatus? CandidateStatus,
         string? PositionId):IRequestBase<ExportCandidatesDTO>;
    public class ExportCandidatesQueryHandler : RequestHandlerBase<Candidate, ExportCandidatesQuery, ExportCandidatesDTO>
    {
        public ExportCandidatesQueryHandler(RequestHandlerBaseParameters<Candidate> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<ExportCandidatesDTO>> Handle(ExportCandidatesQuery request, CancellationToken cancellationToken)
        {
            var CandidatesRequest = request.MapOne<GetAllCandidatesQuery>() with { pageIndex = 1, pageSize = int.MaxValue };
            var candidates = (await _mediator.Send(CandidatesRequest)).Data.Items.ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Candidates");

            worksheet.Cells[1, 1].Value = "Full Name";
            worksheet.Cells[1, 2].Value = "Email";
            worksheet.Cells[1, 3].Value = "Phone";
            worksheet.Cells[1, 4].Value = "Status";
            worksheet.Cells[1, 5].Value = "Management";
            worksheet.Cells[1, 6].Value = "Department";
            worksheet.Cells[1, 7].Value = "Level";
            worksheet.Cells[1, 8].Value = "Position";
            worksheet.Cells[1, 9].Value = "Position Name";
            worksheet.Cells[1, 10].Value = "Job Code";

            for (int i = 0; i < candidates.Count; i++)
            {
                var row = i + 2;
                var c = candidates[i];

                worksheet.Cells[row, 1].Value = c.FirstName+" "+c.LastName;
                worksheet.Cells[row, 2].Value = c.Email;
                worksheet.Cells[row, 3].Value = c.PhoneNumber;
                worksheet.Cells[row, 4].Value = c.CandidateStatus.ToString();
                worksheet.Cells[row, 5].Value = c.Management;
                worksheet.Cells[row, 6].Value = c.Department;
                worksheet.Cells[row, 7].Value = c.Level;
                worksheet.Cells[row, 8].Value = c.Position;
                worksheet.Cells[row, 9].Value = c.PositionName;
                worksheet.Cells[row, 10].Value = c.JobCode;
            }

            worksheet.Cells.AutoFitColumns();

            // ✅ This is where fileBytes is defined
            var fileBytes = package.GetAsByteArray();
            var fileName = $"Candidates_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var result = new ExportCandidatesDTO(fileBytes, fileName, contentType);
            return RequestResult<ExportCandidatesDTO>.Success(result);
        }
    }
}
