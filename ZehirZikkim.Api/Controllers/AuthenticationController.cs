
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZehirZikkim.Application.Auhtentication.Commands.Register;
using ZehirZikkim.Application.Auhtentication.Queries.Login;
using ZehirZikkim.Application.Authentication.Common;
using ZehirZikkim.Contracts.Authentication;


namespace ZehirZikkim.Api.Controllers;



[Route("auth")]
public class AuthController : ApiController
{
    
    private readonly ISender mediator;

    public AuthController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request) {

        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        ErrorOr.ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapResponse(authResult)),
            Problem
        );

       
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request) {

        var command = new LoginCommand(
            request.Email,
            request.Password
        );


        ErrorOr.ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapResponse(authResult)),
            Problem
        );
    }

    private AuthenticationResponse MapResponse(AuthenticationResult authResult) {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }   
}   



