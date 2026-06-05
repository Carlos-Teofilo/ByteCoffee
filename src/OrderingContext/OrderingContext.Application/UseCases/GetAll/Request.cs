using MediatR;

namespace OrderingContext.Application.UseCases.GetAll;

public record Request(
    Guid CustomerId,
    int Page = 0,
    int PageSize = 20) : IRequest<Response>;
