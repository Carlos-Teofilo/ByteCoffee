namespace CatalogContext.Domain.Entities;

public class Product
{
    #region Properties
    
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public bool InStock => Quantity > 0;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    
    #endregion

    #region Constructors

    protected Product() {}

    public Product(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    #endregion
}
