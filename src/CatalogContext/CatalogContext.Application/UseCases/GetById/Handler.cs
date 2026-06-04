using System.Data.Common;
using CatalogContext.Application.UseCases.GetById.Contracts;
using CatalogContext.Application.UseCases.GetById.DTOs;
using CatalogContext.Domain.Entities;
using MediatR;

namespace CatalogContext.Application.UseCases.GetById;

public class Handler(IRepository repository) : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository = repository;
    
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
    {
        Product? product;
        try
        {
            product = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (product is null)
                return new Response("Nenhum produto foi encontrado", 404);
        }
        catch (DbException e)
        {
            return new Response("Erro ao acessar o banco de dados", 500);
        }

        try
        {
            var data = new DetailProductResponse(
                product.Id,
                product.Name,
                product.Description,
                product.Quantity,
                product.Price,
                product.CreatedAt,
                product.UpdatedAt);

            return new Response("Success", data);
        }
        catch (Exception e)
        {
            return new Response(e.Message, 500);
        }
    }
}