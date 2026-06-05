using MediatR;
using OrderingContext.Application.UseCases.Create.Contracts;
using OrderingContext.Application.UseCases.Create.DTOs;
using OrderingContext.Domain.Entities;

namespace OrderingContext.Application.UseCases.Create;

public class Handler(IRepository repository) : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository = repository;
    
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new Response("Requisição inválida", 400, res.Notifications);
        }
        catch (Exception e)
        {
            return new Response("Não foi possível validar a requisição", 500);
        }

        Order order;
        
        try
        {
            order = new Order(request.CustomerId);
            foreach (var item in request.Items)
                order.AddItem(new OrderItem(item.ProductId, item.Name, item.Quantity, item.Price));
            
            order = await _repository.SaveAsync(order, cancellationToken);
        }
        catch (Exception e)
        {
            return new Response("Erro ao salvar no banco de dados", 500);
        }

        try
        {
            var response = new CreateOrderResponse(
                order.Id,
                order.OrderItems.Select(item => new SummaryOrderItemResponse(item.Name, item.Quantity, item.Price, item.Total)),
                order.CalculateTotal());
            
            return new Response("Pedido criado com sucesso!", response);
        }
        catch (Exception e)
        {
            return new Response("Erro ao criar o pedido", 500);
        }
    }
}