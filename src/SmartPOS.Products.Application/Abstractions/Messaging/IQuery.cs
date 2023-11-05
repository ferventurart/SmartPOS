using SmartPOS.Products.Domain.Abstractions;
using MediatR;

namespace SmartPOS.Products.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}