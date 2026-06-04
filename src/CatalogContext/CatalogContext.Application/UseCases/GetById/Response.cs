using CatalogContext.Application.DTOs;
using CatalogContext.Application.UseCases.GetById.DTOs;
using Flunt.Notifications;

namespace CatalogContext.Application.UseCases.GetById;

public class Response : Shared.Response
{
    #region Properties

    public DetailProductResponse? Product { get; set; }

    #endregion
    
    #region Constructors

    protected Response() { }

    public Response(string message, DetailProductResponse data)
    {
        Message = message;
        Product = data;
        StatusCode = 200;
        Notifications = null;
    }

    public Response(
        string message,
        int statusCode,
        IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        StatusCode = statusCode;
        Notifications = notifications;
    }
    
    #endregion
}