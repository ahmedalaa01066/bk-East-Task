using EasyTask.Common.Endpoints;
using EasyTask.Data;
using EasyTask.Models;
using MediatR;

namespace EasyTask.Common.Requests;

public abstract class RequestHandlerBase<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, RequestResult<TResponse>>
    where TRequest : IRequest<RequestResult<TResponse>>
     where TEntity : BaseModel, new()
{
    protected readonly IMediator _mediator;
    protected readonly UserState _userState;
    protected readonly Repository<TEntity> _repository;
    public RequestHandlerBase(RequestHandlerBaseParameters<TEntity> requestParameters)
    {
        _mediator = requestParameters.Mediator;
        _userState = requestParameters.UserState;
        _repository = requestParameters.Repository;
    }

    public abstract Task<RequestResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}
