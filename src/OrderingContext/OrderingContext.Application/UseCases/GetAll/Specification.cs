using Flunt.Notifications;
using Flunt.Validations;

namespace OrderingContext.Application.UseCases.GetAll;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .AreNotEquals(request.CustomerId, Guid.Empty, "CustomerId", "O CustomerId não pode ser vazio");
}