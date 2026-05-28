using OrderingContext.Application.DTOs;
using OrderingContext.Domain.Repositories;

namespace OrderingContext.Application.UseCases;

public class GetOrderUseCase(IOrderRepository repository)
{
    private readonly IOrderRepository _repository = repository;

    public async Task<ListOrdersResponse> GetAllAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var (total, orders) = await _repository.GetAllAsync(customerId, cancellationToken);
        var ordersResponse = orders.Select(x => new SummaryOrderResponse(
            x.Id,
            x.CustomerId,
            x.OrderItems.Select(p => new OrderItemResponse(p.Name, p.Price, p.Quantity, p.Total))
        ));
        
        return new ListOrdersResponse(ordersResponse, Total: total);
    }
}