using AutoMapper;
using EasyTask.Features.Medias.AttachImageToCandidateDocument.Commands;
using EasyTask.Features.Medias.AttachImageToCandidateDocument.Orchestrator;
using FluentValidation;

namespace EasyTask.Features.Medias.AttachImageToCandidateDocument
{
    public record AttachImageToCandidateDocumentRequestViewModel(string SourceId, string DocumentId, string ImagePath);
    public class AttachImageToCandidateDocumentRequestValidator : AbstractValidator<AttachImageToCandidateDocumentRequestViewModel>
    {
        public AttachImageToCandidateDocumentRequestValidator()
        {
        }
    }
    public class AttachImageToCandidateDocumentRequestProfile : Profile
    {
        public AttachImageToCandidateDocumentRequestProfile()
        {
            CreateMap<AttachImageToCandidateDocumentRequestViewModel, AttachImageToCandidateDocumentOrchestrator>();
            CreateMap<AttachImageToCandidateDocumentOrchestrator,AttachImageToCandidateDocumentCommand>();
        }
    }
}
