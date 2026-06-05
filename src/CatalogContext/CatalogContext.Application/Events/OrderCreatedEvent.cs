using System;

namespace CatalogContext.Application.Events;

public record OrderCreatedEvent(
    int OrderId,
    Guid CustomerId,
    decimal TotalAmount);
