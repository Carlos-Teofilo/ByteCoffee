using System;

namespace CatalogContext.Application.UseCases.Create.DTOs;

public record CreateProductResponse(
    Guid Id,
    string Name,
    string? Description,
    int Quantity,
    decimal Price);
