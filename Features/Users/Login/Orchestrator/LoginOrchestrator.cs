using EasyTask.Common.Requests;
using EasyTask.Features.Attendances.StartAttendance.Commands;
using EasyTask.Features.Users.Login.Commands;
using EasyTask.Helpers;
using EasyTask.Models.Users;
using System.IdentityModel.Tokens.Jwt;

namespace EasyTask.Features.Users.Login.Orchestrator
{
    public record LoginOrchestrator(
        string Email,
        string Password
    ) : IRequestBase<LoginResponseDTO>;
    public class LoginOrchestratorCommandHandler : RequestHandlerBase<User, LoginOrchestrator, LoginResponseDTO>
    {
        public LoginOrchestratorCommandHandler(RequestHandlerBaseParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public async override Task<RequestResult<LoginResponseDTO>> Handle(LoginOrchestrator request, CancellationToken cancellationToken)
        {
            var Token = await _mediator.Send(request.MapOne<LoginCommand>());
            if (!Token.IsSuccess)
            {
                return RequestResult<LoginResponseDTO>.Failure(Token.ErrorCode);
            }
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(Token.Data);
            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "ID")?.Value;
            var attendance = await _mediator.Send(new StartAttendanceCommand(userId));
            if (!attendance.IsSuccess)
            {
                return RequestResult<LoginResponseDTO>.Failure(attendance.ErrorCode);
            }
            var result = new LoginResponseDTO(Token.Data, attendance.Data);
            return RequestResult<LoginResponseDTO>.Success(result);
        }

    }
}
