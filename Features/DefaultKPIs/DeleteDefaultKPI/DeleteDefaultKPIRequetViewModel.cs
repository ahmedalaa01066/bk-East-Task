using AutoMapper;
using EasyTask.Features.DefaultKPIs.DeleteDefaultKPI.Commands;
using FluentValidation;

namespace EasyTask.Features.DefaultKPIs.DeleteDefaultKPI
{
    public record DeleteDefaultKPIRequetViewModel(string ID);
    public class DeleteDefaultKPIRequetValidator : AbstractValidator<DeleteDefaultKPIRequetViewModel>
    {
        public DeleteDefaultKPIRequetValidator()
        {
        }
    }
    public class DeleteDefaultKPIRequetProfile : Profile
    {
        public DeleteDefaultKPIRequetProfile()
        {
            CreateMap<DeleteDefaultKPIRequetViewModel, DeleteDefaultKPICommand>();
        }
    }
}
