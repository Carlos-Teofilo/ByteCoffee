using CatalogContext.Domain.Entities;

namespace CatalogContext.Application.DTOs;

public record PagedProductReponse(
    IReadOnlyList<Product> Data);
