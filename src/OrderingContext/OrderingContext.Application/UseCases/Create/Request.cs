using MediatR;
using OrderingContext.Application.UseCases.Create.DTOs;

namespace OrderingContext.Application.UseCases.Create;

public record Request(
    IEnumerable<CreateOrderItemRequest> Items,
    Guid CustomerId) : IRequest<Response>;
