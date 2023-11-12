
using ErrorOr;
using ZehirZikkim.Application.Services.Authentication.Common;

namespace ZehirZikkim.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}