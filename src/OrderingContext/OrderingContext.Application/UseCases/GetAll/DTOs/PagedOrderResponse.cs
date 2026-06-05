namespace OrderingContext.Application.UseCases.GetAll.DTOs;

public record PagedOrderResponse(
    IEnumerable<SummaryOrderResponse> Orders,
    int Total,
    int Page = 0,
    int PageSize = 20);
