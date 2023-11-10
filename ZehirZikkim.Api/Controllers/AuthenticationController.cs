
using Microsoft.AspNetCore.Mvc;
using ZehirZikkim.Application.Services.Authentication;
using ZehirZikkim.Contracts.Authentication;


namespace ZehirZikkim.Api.Controllers;


[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
 
    private readonly IAuthenticationService authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) {

        var authResult = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password

        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request) {

        var authResult = authenticationService.Login(
            request.Email,
            request.Password

        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);
        return Ok(response);
    }
}


