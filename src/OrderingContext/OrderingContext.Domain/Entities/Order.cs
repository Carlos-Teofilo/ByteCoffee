using OrderingContext.Domain.Interfaces;

namespace OrderingContext.Domain.Entities;

public class Order : AggregateRoot
{
    #region Properties

    public int Id { get; private set; }
    public Guid CustomerId { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    #endregion

    #region Constructors
    
    protected Order() {}

    public Order(Guid customerId)
    {
        CustomerId = customerId;
    }
    #endregion
    
    #region Methods
    
    public void AddItem(OrderItem orderItem)
    {
        var existingItem = _orderItems.FirstOrDefault(x => x.ProductId == orderItem.ProductId);

        if (existingItem is not null)
            existingItem.Increase(orderItem.Quantity);
        else
            _orderItems.Add(orderItem);    

        UpdatedAt = DateTime.UtcNow;
    }
    
    public void RemoveItem(Guid productId)
    {
        var item = _orderItems.FirstOrDefault(x => x.ProductId == productId);
        
        if (item is not null)
        {
            _orderItems.Remove(item);
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void DecreaseItemQuantity(Guid productId, int quantity = 1)
    {
        var item = _orderItems.FirstOrDefault(x => x.ProductId == productId);

        if (item is null) return;
        
        if (item.Quantity <= quantity)
            _orderItems.Remove(item);
        else
            item.Decrease(quantity);

        UpdatedAt = DateTime.UtcNow;
    }
    
    public decimal CalculateTotal() => _orderItems.Sum(item => item.Total);
    
    #endregion
    

}
