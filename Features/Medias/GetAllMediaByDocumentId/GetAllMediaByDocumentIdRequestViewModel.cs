using AutoMapper;
using EasyTask.Features.Common.Medias.Queries;
using FluentValidation;

namespace EasyTask.Features.Medias.GetAllMediaByDocumentId
{
    public record GetAllMediaByDocumentIdRequestViewModel(string ParentDocumentId);
    public class GetAllMediaByDocumentIdRequestValidator : AbstractValidator<GetAllMediaByDocumentIdRequestViewModel>
    {
        public GetAllMediaByDocumentIdRequestValidator()
        {
        }
    }
    public class GetAllMediaByDocumentIdRequestProfile : Profile
    {
        public GetAllMediaByDocumentIdRequestProfile()
        {
            CreateMap<GetAllMediaByDocumentIdRequestViewModel, GetAllMediaByDocumentIdQuery>();
        }
    }
}
