
using ErrorOr;
using ZehirZikkim.Application.Services.Authentication.Common;

namespace ZehirZikkim.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}