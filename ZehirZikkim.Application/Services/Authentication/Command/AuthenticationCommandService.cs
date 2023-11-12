using ErrorOr;
using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Application.Services.Authentication.Common;
using ZehirZikkim.Domain.Common.Errors;
using ZehirZikkim.Domain.Entities;
namespace ZehirZikkim.Application.Services.Authentication.Command;

public class AuthenticationService : IAuthenticationCommandService
{

    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {

        // validate user doesn't exists
        if(userRepository.GetUserByEmail(email) is null) {
            return Errors.User.EmailConflictException;
        }

        Guid userId = Guid.NewGuid();
          // create a new user (generate unique identifier)
        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        userRepository.Add(user);

      


        // create jwt token
        string token = jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }

}