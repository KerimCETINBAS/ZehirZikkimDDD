
using ErrorOr;
using ZehirZikkim.Domain.Common.Errors;
using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Domain.Entities;
using ZehirZikkim.Application.Services.Authentication.Common;

namespace ZehirZikkim.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{

    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {

        // validate user doesn't exists
        if(userRepository.GetUserByEmail(email) != null) {
            return Errors.User.DuplicateEmailException;
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