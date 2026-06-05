using System.Collections.Generic;

namespace CatalogContext.Application.UseCases.GetAll.DTOs;

public record PagedProductResponse(
    IEnumerable<SummaryProductResponse> Products,
    int Page,
    int PageSize,
    int Total);
