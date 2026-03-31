using AutoMapper;
using EasyTask.Features.Common.ExternalMembers.Queries;
using FluentValidation;

namespace EasyTask.Features.ExternalMembers.ExternalMemberSelectList
{
    public record ExternalMemberSelectListRequestViewModel(string? Name);
    public class ExternalMemberSelectListRequestValidator : AbstractValidator<ExternalMemberSelectListRequestViewModel>
    {
        public ExternalMemberSelectListRequestValidator()
        {
        }
    }
    public class ExternalMemberSelectListRequestProfile : Profile
    {
        public ExternalMemberSelectListRequestProfile()
        {
            CreateMap<ExternalMemberSelectListRequestViewModel, ExternalMemberSelectListQuery>();
        }
    }
}
