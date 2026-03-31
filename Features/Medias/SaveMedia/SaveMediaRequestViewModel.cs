using AutoMapper;
using FluentValidation;
using EasyTask.Features.Medias.SaveMedia.Commands;
using EasyTask.Models.Enums;

namespace EasyTask.Features.Medias.SaveMedia
{
    public record SaveMediaRequestViewModel(string SourceId, SourceType SourceType, List<string> Paths);
    public class SaveMediaRequestValidator:AbstractValidator<SaveMediaRequestViewModel>
    {
        public SaveMediaRequestValidator() { }
    }
    public class SaveMediaRequestProfile : Profile
    {
        public SaveMediaRequestProfile()
        {
            CreateMap<SaveMediaRequestViewModel, SaveMediaCommand>();
        }
    }
}
