using MediatR;

namespace CatalogContext.Application.UseCases.Create;

public record Request(
    string Name,
    string Description,
    int Quantity,
    decimal Price) : IRequest<Response>;
