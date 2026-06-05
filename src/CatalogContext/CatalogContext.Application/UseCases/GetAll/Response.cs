using System.Collections.Generic;
using CatalogContext.Application.UseCases.GetAll.DTOs;
using Flunt.Notifications;

namespace CatalogContext.Application.UseCases.GetAll;

public class Response : Shared.Response
{
    #region Properties
    
    public PagedProductResponse? Data { get; set; }
    
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

    public Response(string message, PagedProductResponse data)
    {
        Message = message;
        StatusCode = 200;
        Data = data;
        Notifications = null;
    }
    
    #endregion
}