using AutoMapper;
using EasyTask.Features.Common.Medias.DTOs;
using EasyTask.Features.Medias.AttachMediaToDocument.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.Medias.AttachMediaToDocument
{
    public record AttachMediaToDocumentRequestViewModel(string SourceId, string DocumentId,
        List<AttachMediaToDocumentDTO> attachMediaToDocumentDTOs);
    public class AttachMediaToDocumentRequestValidator : AbstractValidator<AttachMediaToDocumentRequestViewModel>
    {
        public AttachMediaToDocumentRequestValidator()
        {
        }
    }
    public class AttachMediaToDocumentRequestProfile : Profile
    {
        public AttachMediaToDocumentRequestProfile()
        {
            CreateMap<AttachMediaToDocumentRequestViewModel, AttachMediaToDocumentCommand>();
        }
    }
}
