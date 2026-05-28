using OrderingContext.Domain.Entities;

namespace OrderingContext.Application.DTOs;

public record ListOrdersResponse(
    IEnumerable<SummaryOrderResponse> Orders,
    int Page = 1,
    int PageSize = 20,
    int Total = 0);
