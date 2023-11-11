
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ZehirZikkim.Api.Middleware;
public class ErrorHandlingMiddleware {

    
    private readonly RequestDelegate next;


    public ErrorHandlingMiddleware(RequestDelegate next) {
        this.next = next;
    }



    public async Task Invoke(HttpContext context) {

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            
            await HandleExceptionAsync(context, ex);
        }
    }


    private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
     
        HttpStatusCode code = HttpStatusCode.InternalServerError; // 500 if unexpected

        var result = JsonSerializer.Serialize(new { error = "Unexpected error occoured"});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }

}