using System.Data.Common;
using MediatR;
using OrderingContext.Application.UseCases.GetAll.Contracts;
using OrderingContext.Application.UseCases.GetAll.DTOs;
using OrderingContext.Domain.Entities;

namespace OrderingContext.Application.UseCases.GetAll;

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
        catch (Exception ex)
        {
            return new Response("Não foi possível validar a requisição", 500);
        }
        
        try
        {
            var (orders, total) = await _repository.GetAllAsync(request.Page, request.PageSize, cancellationToken);
            
            var orderFormatted = orders
                .Select(order => new SummaryOrderResponse(
                    order.Id,
                    order.OrderItems.Select(item => new SummaryOrderItemResponse(item.Name, item.Quantity)),
                    order.CalculateTotal())
                ).ToList();
            
            return new Response(
                "Success",
                new PagedOrderResponse(orderFormatted, total, request.Page, request.PageSize)
            );
        }
        catch (DbException ex)
        {
            return new Response("Erro ao acessar o banco dados", 500);
        }
        catch (Exception ex)
        {
            return new Response("Erro interno do servidor", 500);
        }
        
    }
}