using AutoMapper;
using FluentValidation;
using EasyTask.Features.Common.RoleFeatures.Queries;

namespace EasyTask.Features.RoleFeatures.GetAllFeaturesListed
{
    public record GetAllFeaturesListedRequestViewModel(int RoleID, string? FeatureName);
    public class GetAllFeaturesListedRequestValidator : AbstractValidator<GetAllFeaturesListedRequestViewModel>
    {
        public GetAllFeaturesListedRequestValidator()
        {
        }
    }

    public class GetAllFeaturesListedRequestProfile : Profile
    {
        public GetAllFeaturesListedRequestProfile()
        {
            CreateMap<GetAllFeaturesListedRequestViewModel, GetAllFeaturesListedQuery>();
        }
    }
}
