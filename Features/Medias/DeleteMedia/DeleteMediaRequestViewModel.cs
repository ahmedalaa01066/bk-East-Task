using AutoMapper;
using FluentValidation;
using EasyTask.Features.Medias.DeleteMedia.Commands;

namespace EasyTask.Features.Medias.DeleteMedia
{
    public record DeleteMediaRequestViewModel(string ID);

    public class DeleteMediaRequestValidator : AbstractValidator<DeleteMediaRequestViewModel>
    {
        public DeleteMediaRequestValidator() { }
    }
    public class DeleteMediaRequestProfile : Profile
    {
        public DeleteMediaRequestProfile()
        {
            CreateMap<DeleteMediaRequestViewModel, DeleteMediaCommand>();
        }
    }
}
