using Flunt.Notifications;
using Flunt.Validations;

namespace OrderingContext.Application.UseCases.Create;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
    {
        var contract = new Contract<Notification>()
            .Requires()
            .AreNotEquals(request.CustomerId, Guid.Empty, "CustomerId", "O ID do cliente não pode ser vazio")
            .IsNotNull(request.Items, "Items", "A lista de itens não pode ser nula");
        
        if (!request.Items.Any())
        {
            contract.AddNotification("Items", "O pedido deve conter pelo menos um item");
            return contract;
        }

        foreach (var item in request.Items)
            contract
                .AreNotEquals(item.ProductId, Guid.Empty, "ProductId", "O ID do produto não pode ser vazio")
                .IsNotNullOrEmpty(item.Name, "Name", "O nome do produto é obrigatório")
                .IsGreaterThan(item.Price, 0.01m, "Price", "O preço do produto deve ser maior que 0.01")
                .IsGreaterThan(item.Quantity, 0, "Quantity", "A quantidade do produto deve ser maior que zero");

        return contract;
    }
}