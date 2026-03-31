using AutoMapper;
using FluentValidation;
using EasyTask.Features.Medias.UploadMedia.Commands;

namespace EasyTask.Features.Medias.UploadMedia
{
    public record UploadMediaResponseViewModel(List<string> Path);

    public class UploadMediaResponseValidator : AbstractValidator<UploadMediaResponseViewModel>
    {
        public UploadMediaResponseValidator()
        {
        }
    }

    public class UploadMediaResponseEndPointRequestProfile : Profile
    {
        public UploadMediaResponseEndPointRequestProfile()
        {
            // Map the command response (list of strings) to the response view model
            CreateMap<List<string>, UploadMediaResponseViewModel>()
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src));
        }
    }
}