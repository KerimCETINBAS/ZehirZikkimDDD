using ErrorOr;
using MediatR;
using ZehirZikkim.Application.Authentication.Common;

namespace ZehirZikkim.Application.Auhtentication.Queries.Login;



public record LoginQuery(
    string Email,
    string Password):IRequest<ErrorOr<AuthenticationResult>>;