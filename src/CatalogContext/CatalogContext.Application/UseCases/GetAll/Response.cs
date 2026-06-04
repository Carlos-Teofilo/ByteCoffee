using CatalogContext.Application.UseCases.GetAll.DTOs;
using Flunt.Notifications;

namespace CatalogContext.Application.UseCases.GetAll;

public class Response : Shared.Response
{
    #region Properties
    
    public PagedProductReponse? Data { get; set; }
    
    #endregion
    
    #region Constructors

    protected Response() { }

    public Response(
        string message,
        int statusCode,
        IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        StatusCode = statusCode;
        Notifications = notifications;
    }

    public Response(string message, PagedProductReponse data)
    {
        Message = message;
        StatusCode = 200;
        Data = data;
        Notifications = null;
    }
    
    #endregion
}