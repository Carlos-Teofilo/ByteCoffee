using System;

namespace CatalogContext.Application.UseCases.GetById.DTOs;

public record DetailProductResponse(
    Guid Id,
    string Name,
    string? Description,
    int Quantity,
    decimal Price,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
