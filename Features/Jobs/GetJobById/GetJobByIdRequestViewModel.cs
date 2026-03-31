using AutoMapper;
using EasyTask.Features.Common.Jobs.Quereies;
using FluentValidation;

namespace EasyTask.Features.Jobs.GetJobById
{
    public record GetJobByIdRequestViewModel(string ID);
    public class GetJobByIdRequestValidator : AbstractValidator<GetJobByIdRequestViewModel>
    {
        public GetJobByIdRequestValidator()
        {
        }
    }
    public class GetJobByIdRequestProfile : Profile
    {
        public GetJobByIdRequestProfile()
        {
            CreateMap<GetJobByIdRequestViewModel, GetJobByIdQuery>();
        }
    }
}
