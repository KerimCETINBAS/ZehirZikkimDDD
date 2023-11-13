
using MapsterMapper;
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
    private readonly IMapper mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request) {

        var command = mapper.Map<RegisterCommand>(request);
        ErrorOr.ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

        return authResult.Match(
            authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
            Problem
        );

       
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request) {

       
        LoginQuery query = mapper.Map<LoginQuery>(request);
        ErrorOr.ErrorOr<AuthenticationResult> authResult = await mediator.Send(query);

        return authResult.Match(
            authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
            Problem
        );

    }
}   



