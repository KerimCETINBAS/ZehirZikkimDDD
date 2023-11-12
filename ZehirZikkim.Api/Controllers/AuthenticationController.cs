
using Microsoft.AspNetCore.Mvc;
using ZehirZikkim.Application.Services.Authentication.Commands;
using ZehirZikkim.Application.Services.Authentication.Common;
using ZehirZikkim.Application.Services.Authentication.Queries;
using ZehirZikkim.Contracts.Authentication;


namespace ZehirZikkim.Api.Controllers;


[Route("auth")]
public class AuthController : ApiController
{
    
    private readonly IAuthenticationQueryService  authenticationQueryService;
    private readonly IAuthenticationCommandService authenticationCommandService;

    public AuthController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
    {
        this.authenticationCommandService = authenticationCommandService;
        this.authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) {

        ErrorOr.ErrorOr<AuthenticationResult> authResult = authenticationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password

        );

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }
    

    private AuthenticationResponse MapAuthResult (AuthenticationResult authResult) {
            return new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request) {

        ErrorOr.ErrorOr<AuthenticationResult> authResult = authenticationQueryService.Login(
            request.Email,
            request.Password
        );

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }
}


