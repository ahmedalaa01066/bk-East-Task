using EasyTask.Common.Endpoints;
using EasyTask.Data;
using EasyTask.Models;
using MediatR;

namespace EasyTask.Common.Requests;

public interface IRequestBase<TResponse> : IRequest<RequestResult<TResponse>>
{ }
