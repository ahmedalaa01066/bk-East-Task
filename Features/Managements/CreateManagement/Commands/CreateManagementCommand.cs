using EasyTask.Common.Enums;
using EasyTask.Common.Requests;
using EasyTask.Helpers;
using EasyTask.Models.Managements;

namespace EasyTask.Features.Managements.CreateManagement.Commands
{
    public record CreateManagementCommand(string Name, string ManagerId) : IRequestBase<string>;

    public class CreateManagementCommandHandler : RequestHandlerBase<Management, CreateManagementCommand, string>
    {
        public CreateManagementCommandHandler(RequestHandlerBaseParameters<Management> parameters) : base(parameters)
        { }

        public async override Task<RequestResult<string>> Handle(CreateManagementCommand request, CancellationToken cancellationToken)
        {
            var managerExists = await _repository.AnyAsync(m => m.ManagerId == request.ManagerId);
            if (managerExists)
                return RequestResult<string>.Failure(ErrorCode.DuplicateManager);

            Management Management = new Management { 
                Name = request.Name, 
                IsActive = true,
                ManagerId=request.ManagerId,
                Code = GenerateGenericCode.Generate("MG")
            };
            _repository.Add(Management);
            _repository.SaveChanges();

            var result = RequestResult<string>.Success(Management.ID);
            return await Task.FromResult(result);
        }

    }
}
