using OrderingContext.Domain.Interfaces;

namespace OrderingContext.Domain.Entities;

public class OrderItem : Entity
{
    #region Properties

    public int Id { get; private set; }
    public string Name { get; private set; } = null!; // 🟢 Inicializado para evitar o warning de nulo do C#
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Total => Quantity * Price;
    
    public int OrderId { get; private set; }
    public Guid ProductId { get; private set; }

    #endregion

    #region Constructors
    
    protected OrderItem() {}
    
    public OrderItem(Guid productId, string name, int quantity, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        Quantity = quantity < 1 ? 1 : quantity; // Garante que ninguém crie um item com quantidade zerada ou negativa
    }

    #endregion

    #region Behaviors

    public void Increase(int quantity = 1) => Quantity += quantity;
    
    public void Decrease(int quantity = 1) => Quantity -= quantity; // Corrigido o espaço duplo que estava no 'public'

    #endregion
}