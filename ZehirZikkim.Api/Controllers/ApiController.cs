
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ZehirZikkim.Api.Common.Http;

namespace ZehirZikkim.Api.Controllers;
[ApiController]
public class ApiController: ControllerBase {

    protected IActionResult Problem(List<Error> errors) {
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        Error error = errors.First();

        
        int statusCode = error.Code switch {
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

}