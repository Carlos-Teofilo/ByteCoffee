using MassTransit;
using OrderingContext.Application.DTOs;
using CatalogContext.Domain.Repositories;

namespace CatalogContext.Infrastructure.Messaging.Consumers;

public class OrderCreatedConsumer(IProductRepository productRepository)
    : IConsumer<OrderCreatedEvent>
{
    private readonly IProductRepository _productRepository = productRepository;

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