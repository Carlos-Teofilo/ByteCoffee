namespace CatalogContext.Application.UseCases;

public interface IBaixarEstoqueUseCase
{
    Task ExecuteAsync(int orderId, decimal totalAmount);
}