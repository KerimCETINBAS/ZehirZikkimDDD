using ErrorOr;
using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Application.Services.Authentication.Common;
using ZehirZikkim.Domain.Common.Errors;
using ZehirZikkim.Domain.Entities;

namespace ZehirZikkim.Application.Services.Authentication.Query;

public class AuthenticationQueryService : IAuthenticationQueryService
{

    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }


    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // validate user exists
        if(userRepository.GetUserByEmail(email) is not User user) {
          
            return Errors.Auth.CredentialsInvalidException;
        }
        // validate password if user exists
        if (user.Password != password) {
            return Errors.Auth.CredentialsInvalidException;
        }
        // create token
        string token = jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return new AuthenticationResult(Guid.NewGuid(), user.FirstName, user.LastName, email, token);
    }
}