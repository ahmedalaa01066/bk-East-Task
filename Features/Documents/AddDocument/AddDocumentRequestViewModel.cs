
using AutoMapper;
using EasyTask.Features.Documents.AddDocument.Commands;
using FluentValidation;

namespace EasyTask.Features.Documents.AddDocument
{
    public record AddDocumentRequestViewModel(string Name, string ParentDocumentId);
    public class AddDocumentRequestValidator : AbstractValidator<AddDocumentRequestViewModel>
    {
        public AddDocumentRequestValidator()
        {
        }
    }
    public class AddDocumentRequestProfile : Profile
    {
        public AddDocumentRequestProfile()
        {
            CreateMap<AddDocumentRequestViewModel, AddFolderCommand>();
        }
    }
}
