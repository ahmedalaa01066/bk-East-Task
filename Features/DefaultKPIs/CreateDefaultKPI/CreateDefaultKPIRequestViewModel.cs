using AutoMapper;
using EasyTask.Features.DefaultKPIs.CreateDefaultKPI.Commands;
using EasyTask.Models.Enums;
using FluentValidation;

namespace EasyTask.Features.DefaultKPIs.CreateDefaultKPI
{
    public record CreateDefaultKPIRequestViewModel(string Name, KPIType Type, double Percentage);
    public class CreateDefaultKPIRequestValidtor : AbstractValidator<CreateDefaultKPIRequestViewModel>
    {
        public CreateDefaultKPIRequestValidtor()
        {
        }
    }
    public class CreateDefaultKPIRequestProfile : Profile
    {
        public CreateDefaultKPIRequestProfile()
        {
            CreateMap<CreateDefaultKPIRequestViewModel, CreateDefaultKPICommand>();
        }
    }
}
