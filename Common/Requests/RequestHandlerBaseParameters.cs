using EasyTask.Common.Endpoints;
using EasyTask.Data;
using EasyTask.Models;
using MediatR;

namespace EasyTask.Common.Requests;

public record RequestHandlerBaseParameters<T>(IMediator Mediator, UserState UserState, Repository<T> Repository) 
    where T : BaseModel, new();
