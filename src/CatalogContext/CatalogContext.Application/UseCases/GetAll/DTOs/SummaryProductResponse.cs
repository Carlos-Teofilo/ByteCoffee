using System;

namespace CatalogContext.Application.UseCases.GetAll.DTOs;

public record SummaryProductResponse(
    Guid Id,
    string Name,
    string? Description,
    int Quantity,
    decimal Price);