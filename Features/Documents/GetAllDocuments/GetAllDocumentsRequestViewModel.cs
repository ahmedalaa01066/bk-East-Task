using AutoMapper;
using EasyTask.Features.Common.Documents.Queries;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Documents.GetAllDocuments
{
    public record GetAllDocumentsRequestViewModel(DocumentType? SourceType, string? ParentDocumentId, int pageIndex = 1,
        int pageSize = 100);
    public class GetAllDocumentsRequestValidator : AbstractValidator<GetAllDocumentsRequestViewModel>
    {
        public GetAllDocumentsRequestValidator()
        {
        }
    }
    public class GetAllDocumentsRequestProfile : Profile
    {
        public GetAllDocumentsRequestProfile() {
            CreateMap<GetAllDocumentsRequestViewModel, GetAllDocumentsQuery>();
        }
    }
}
