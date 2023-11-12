using ErrorOr;
using ZehirZikkim.Application.Services.Authentication.Common;

namespace ZehirZikkim.Application.Services.Authentication.Query;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}