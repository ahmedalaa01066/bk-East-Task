using AutoMapper;
using EasyTask.Features.Common.Medias.Queries;
using FluentValidation;

namespace EasyTask.Features.Medias.DownloadMedia
{
    public record DownloadMediaRequestViewModel(string ID);
    public class DownloadMediaRequestValidator : AbstractValidator<DownloadMediaRequestViewModel>
    {
        public DownloadMediaRequestValidator()
        {
        }
    }
    public class DownloadMediaRequestProfile : Profile
    {
        public DownloadMediaRequestProfile()
        {
            CreateMap<DownloadMediaRequestViewModel, DownloadMediaQuery>();
        }
    }
}
