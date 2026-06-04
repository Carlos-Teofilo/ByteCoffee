namespace CatalogContext.Application.UseCases.GetAll.DTOs;

public record PagedProductReponse(
    IEnumerable<SummaryProductResponse> Products,
    int Page,
    int PageSize,
    int Total);
