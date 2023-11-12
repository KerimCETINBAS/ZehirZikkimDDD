using ErrorOr;
using MediatR;
using ZehirZikkim.Application.Authentication.Common;

namespace ZehirZikkim.Application.Auhtentication.Commands.Register;


public record RegisterCommand(  
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;