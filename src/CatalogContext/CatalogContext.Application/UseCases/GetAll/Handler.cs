using CatalogContext.Application.UseCases.GetAll.Contracts;
using CatalogContext.Application.UseCases.GetAll.DTOs;
using MediatR;

namespace CatalogContext.Application.UseCases.GetAll;

public class Handler(IRepository repository) : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository = repository;
    
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        try
        {
            var res = Specification.Ensure(request);
            if(!res.IsValid)
                return new Response("Requisição inválida", 400, res.Notifications);
        }
        catch (Exception e)
        {
            return new Response("Não foi possível validar a requisição", 500);
        }

        try
        {
            var (products, total) = await _repository.GetAllAsync(request.Page, request.PageSize, cancellationToken);
            var formattedOutput = products.Select(x => new SummaryProductResponse(x.Id, x.Name, x.Description, x.Quantity, x.Price));
            var pagedResponse = new PagedProductReponse(formattedOutput, request.Page, request.PageSize, total);
            return new Response("Requisição aprovada", pagedResponse);
        }
        catch (Exception e)
        {
            return new Response("Erro ao consultar o banco de dados", 500);
        }
    }
}