namespace CatalogContext.Application.DTOs;

public record DetailProductResponse(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    DateTime CreatedAt,
    DateTime? UpdatedAt);