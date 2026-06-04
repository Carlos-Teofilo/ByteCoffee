using MediatR;

namespace CatalogContext.Application.UseCases.GetAll;

public record Request(
    int Page = 0,
    int PageSize = 20) : IRequest<Response>;
