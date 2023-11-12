using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ZehirZikkim.Api.Common.Http;

namespace ZehirZikkim.Api.Controllers;



[ApiController]
public class ApiController: ControllerBase {

    protected IActionResult Problem(List<Error> errors) {

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        Error error = errors[0];

        int statusCode = error.Code switch {
            "User.DuplicateEmailException" => StatusCodes.Status409Conflict,
            "Authentication.InvalidCredentials" => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
        return Problem(
            statusCode: statusCode,
            title: error.Code,
            detail: error.Description
        );
    }
}