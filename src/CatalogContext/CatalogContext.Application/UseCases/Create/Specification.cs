using CatalogContext.Application.UseCases.Create.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace CatalogContext.Application.UseCases.Create;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Name.Length, 120, "Name", "O nome deve ser menor que 120 caracteres.")
            .IsGreaterThan(request.Name.Length, 3, "Name", "O nome deve ser maior que 3 caracteres.")
            .IsLowerThan(request.Description.Length, 500, "Description",
                "A descrição deve ser menor que 500 caracteres.")
            .IsGreaterThan(request.Description.Length, 3, "Description",
                "A descrição deve ser maior que 3 caracteres.")
            .IsGreaterOrEqualsThan(request.Quantity, 0, "Quantity", "A quantidade deve ser maior ou igual a 0")
            .IsGreaterOrEqualsThan(request.Price, 0.1m, "Price", "O preço deve ser maior ou igual a 0,10");
}
