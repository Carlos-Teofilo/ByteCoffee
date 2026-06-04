using CatalogContext.Application.UseCases.Create.DTOs;
using Flunt.Notifications;

namespace CatalogContext.Application.UseCases.Create;

public class Response : Shared.Response
{
    #region Properties

    public CreateProductResponse Data { get; private set; }

    #endregion

    #region Constructors

    protected Response() {  }

    public Response(string message, CreateProductResponse data)
    {
        Message = message;
        StatusCode = 201;
        Data = data;
        Notifications = null;
    }

    public Response(
        string message,
        int statusCode,
        IEnumerable<Notification>? notifications = null
    )
    {
        Message = message;
        StatusCode = statusCode;
        Notifications = notifications;
    }
    
    #endregion
}