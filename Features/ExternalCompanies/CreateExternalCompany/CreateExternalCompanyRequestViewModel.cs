using AutoMapper;
using EasyTask.Features.ExternalCompanies.CreateExternalCompany.Commands;
using FluentValidation;

namespace EasyTask.Features.ExternalCompanies.CreateExternalCompany
{
    public record CreateExternalCompanyRequestViewModel(string Name, string? Location);
    public class CreateExternalCompanyRequestValidator : AbstractValidator<CreateExternalCompanyRequestViewModel>
    {
        public CreateExternalCompanyRequestValidator() { }
    }
    public class CreateExternalCompanyRequestProfile:Profile
    {
        public CreateExternalCompanyRequestProfile()
        {
            CreateMap<CreateExternalCompanyRequestViewModel, CreateExternalCompanyCommand>();
        }
    }
}
