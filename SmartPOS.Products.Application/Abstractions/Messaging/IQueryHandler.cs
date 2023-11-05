using SmartPOS.Products.Domain.Abstractions;
using MediatR;

namespace SmartPOS.Products.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}