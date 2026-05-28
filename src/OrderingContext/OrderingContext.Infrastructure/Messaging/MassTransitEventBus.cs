using MassTransit;
using OrderingContext.Application.Interfaces;

namespace OrderingContext.Infrastructure.Messaging;

public class MassTransitEventBus(
    IPublishEndpoint publishEndpoint) : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        await _publishEndpoint.Publish(message, cancellationToken);
    }
}