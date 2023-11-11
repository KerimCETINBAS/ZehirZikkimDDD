using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ZehirZikkim.Api.Filters;


public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute {

    public override void OnException(ExceptionContext context) {

        Exception exception = context.Exception;

        ProblemDetails problemDetails = new(){
            Type = "https://www.rfc-editor.org/rfc/rfc9110#status.500",
            Title = "Unexpected error occoured in the system",
            Instance = context.HttpContext.Request.Path,
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = exception.Message
        };
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}