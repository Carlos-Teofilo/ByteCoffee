using Flunt.Notifications;
using OrderingContext.Application.UseCases.Create.DTOs;

namespace OrderingContext.Application.UseCases.Create;

public class Response : Shared.Response
{
    #region Properties

    public CreateOrderResponse? Order { get; set; }

    #endregion
    
    #region Constructors
    
    protected Response() { }

    public Response(string message, CreateOrderResponse order)
    {
        Message = message;
        Order = order;
        StatusCode = 201;
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
