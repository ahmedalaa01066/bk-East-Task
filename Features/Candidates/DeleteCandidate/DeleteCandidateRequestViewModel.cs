using AutoMapper;
using EasyTask.Features.Candidates.DeleteCandidate.Commands;
using FluentValidation;

namespace EasyTask.Features.Candidates.DeleteCandidate
{
    public record DeleteCandidateRequestViewModel(string ID);
    public class DeleteCandidateRequestValidator:AbstractValidator<DeleteCandidateRequestViewModel>
    {
        public DeleteCandidateRequestValidator() { }
    }
    public class DeleteCandidateRequestProfile : Profile
    {
        public DeleteCandidateRequestProfile()
        {
            CreateMap<DeleteCandidateRequestViewModel, DeleteCandidateCommand>();
        }
    }
}
