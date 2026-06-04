using CatalogContext.Application.DTOs;
using CatalogContext.Application.UseCases.Create.Contracts;
using CatalogContext.Application.UseCases.Create.DTOs;
using CatalogContext.Domain.Entities;
using MediatR;

namespace CatalogContext.Application.UseCases.Create;

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

        Product product;
        try
        {
            product = new Product(request.Name, request.Description, request.Quantity, request.Price);
        }
        catch (Exception e)
        {
            return new Response("Bad request", 404);
        }

        try
        {
            await _repository.SaveAsync(product, cancellationToken);
        }
        catch
        {
            return new Response("Erro ao salvar produto", 500);
        }
        
        return new Response(
            "Produto salvo com sucesso",
            new CreateProductResponse(product.Id, product.Name, product.Description, product.Quantity, product.Price));
    }
}
