using EasyTask.Common.Endpoints;
using EasyTask.Features.Common.RoleFeatures;
using EasyTask.Models.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EasyTask.Middlewares;

public class CustomizedAuthorizeAttribute : ActionFilterAttribute
{
    Feature _feature;
    UserState _userState;
    private readonly IMediator _mediator; 

    public CustomizedAuthorizeAttribute(Feature feature, UserState userState, IMediator mediator)
    {
        _feature = feature;
        _userState = userState;
        _mediator = mediator;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var loggedUser = context.HttpContext.User;

        var roleID = loggedUser.FindFirst("RoleID");

        if (roleID is null || string.IsNullOrEmpty(roleID.Value))
        {
            throw new UnauthorizedAccessException();
        }
        Role RoleId =(Role)Enum.Parse(typeof(Role),roleID.Value);
        var query = new CheckRoleFeatureAccessQuery(RoleId, _feature);
        var hasAccessResult =  _mediator.Send(query).Result;

        if (!hasAccessResult.Data)
        {
            throw new UnauthorizedAccessException();
        }

        _userState.RoleID = (Role)Enum.Parse(typeof(Role), roleID.Value);
        _userState.UserID = loggedUser.FindFirst("ID")?.Value ?? "";
        _userState.Username = loggedUser.FindFirst(ClaimTypes.Name)?.Value ?? "";

        base.OnActionExecuting(context);
    }
}
