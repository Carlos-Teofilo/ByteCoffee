using CatalogContext.Application.Events;
using MassTransit;

namespace CatalogContext.Infrastructure.Messaging.Consumers;

public class OrderCreatedConsumer(
    CatalogContext.Application.UseCases.Create.Contracts.IRepository productRepository
    )
    : IConsumer<OrderCreatedEvent>
{
    private readonly CatalogContext.Application.UseCases.Create.Contracts.IRepository _productRepository = productRepository;

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var message = context.Message;
        
        Console.WriteLine($"[RabbitMQ] Sucesso! Pedido recebido no Catálogo. ID: {message.OrderId}, Total: R$ {message.TotalAmount}");

        try
        {
            // TODO: No futuro, sua lógica usando o repositório entrará aqui:
            // var produto = await _productRepository.ObterPorIdAsync(...);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[RabbitMQ] Erro ao processar banco de dados: {ex.Message}");
            throw;
        }
    }
}