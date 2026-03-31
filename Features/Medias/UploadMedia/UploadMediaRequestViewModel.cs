using AutoMapper;
using FluentValidation;
using EasyTask.Models.Enums;
using EasyTask.Features.Medias.UploadMedia.Commands;

namespace EasyTask.Features.Medias.UploadMedia;

public record UploadMediaRequestViewModel(IFormFileCollection Files, string Path = "Media");

public class UploadMediaRequestValidator : AbstractValidator<UploadMediaRequestViewModel>
{
    public UploadMediaRequestValidator()
    {
        RuleFor(x => x.Files).NotEmpty().WithMessage("Files are required.");
    }
}

public class UploadMediaEndPointRequestProfile : Profile
{
    public UploadMediaEndPointRequestProfile()
    {
        // Map the file collection from view model to command
        CreateMap<UploadMediaRequestViewModel, UploadMediaCommand>()
            .ForMember(dest => dest.Files, opt => opt.MapFrom(src => src.Files));
    }
}

