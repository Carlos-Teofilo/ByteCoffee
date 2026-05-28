using OrderingContext.Application.DTOs;
using OrderingContext.Application.Interfaces;
using OrderingContext.Domain.Entities;
using OrderingContext.Domain.Repositories;

namespace OrderingContext.Application.UseCases;

public class CreateOrderUseCase(
    IOrderRepository repository,
    IEventBus eventBus
    )
{
    private readonly IOrderRepository _repository = repository;
    private readonly IEventBus _eventBus = eventBus;
    
    public async Task<SummaryOrderResponse> ExecuteAsync(
        CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var order = new Order(request.CustomerId);
        
        foreach (var item in request.OrderItems) 
        {
            var orderItem = new OrderItem(
                item.ProductId,
                item.Name,
                item.Quantity,
                item.Price);
        
            order.AddItem(orderItem);
        }
    
        await _repository.AddAsync(order, cancellationToken);
    
        var total = order.OrderItems.Sum(orderItem => orderItem.Price);

        await _eventBus.PublishAsync(
            new OrderCreatedEvent(order.Id, order.CustomerId, total), cancellationToken);
        
        var orderItems = order.OrderItems.Select(x =>
            new OrderItemResponse(x.Name, x.Price, x.Quantity, x.Total));        
    
        return new SummaryOrderResponse(order.Id, order.CustomerId, orderItems);
    }
}
