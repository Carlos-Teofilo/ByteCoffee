using Flunt.Notifications;
using Flunt.Validations;

namespace CatalogContext.Application.UseCases.GetAll;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .IsGreaterOrEqualsThan(request.Page, 0, "Page", "Page deve ser maior ou igual a 0")
            .IsGreaterThan(request.PageSize, 0, "PageSize", "PageSize deve ser maior 0")
            .IsLowerOrEqualsThan(request.PageSize, 50, "PageSize", "PageSize deve ser menor ou igual a 50");
}