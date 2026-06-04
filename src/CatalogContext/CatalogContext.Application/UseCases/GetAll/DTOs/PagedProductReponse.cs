namespace CatalogContext.Application.UseCases.GetAll.DTOs;

public record PagedProductReponse(
    IEnumerable<SummaryProductResponse> Items,
    int Page,
    int PageSize,
    int Total);
