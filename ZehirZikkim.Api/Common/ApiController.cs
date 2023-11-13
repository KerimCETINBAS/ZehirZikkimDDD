
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ZehirZikkim.Api.Common.Http;

namespace ZehirZikkim.Api.Controllers;

[ApiController]
public class ApiController: ControllerBase {

    protected IActionResult Problem(List<Error> errors)
    {   

        if (errors.Count is 0) return Problem();

        if (errors.All(e => e.Type == ErrorType.Validation)) return ValidationProblem(errors);
    
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        Error error = errors.First();


        int statusCode = error.Code switch
        {
            "Auth.InvalidCredentialsException" => StatusCodes.Status401Unauthorized,
            "User.EmailConflictException" => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            statusCode: statusCode,
            title: error.Code,
            detail: error.Description
        );
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
            ModelStateDictionary modelStateDictionary = new();
            errors.ForEach(e => modelStateDictionary.AddModelError(e.Code, e.Description));
            return ValidationProblem(modelStateDictionary);
    }
}