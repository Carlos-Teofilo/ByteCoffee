using Flunt.Notifications;
using OrderingContext.Application.UseCases.GetAll.DTOs;

namespace OrderingContext.Application.UseCases.GetAll;

public class Response : Shared.Response
{
    #region Properties

    public PagedOrderResponse? Data { get; set; } = null;

    #endregion
    
    #region Constructors
    
    protected Response() { }

    public Response(string message, PagedOrderResponse data)
    {
        Message = message;
        Data = data;
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