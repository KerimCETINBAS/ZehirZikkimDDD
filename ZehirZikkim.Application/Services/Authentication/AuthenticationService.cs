using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Domain.Entities;

namespace ZehirZikkim.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        // validate user doesn't exists
        if(userRepository.GetUserByEmail(email) != null) {
            throw new Exception("User with given email already exist");
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

    public AuthenticationResult Login(string email, string password)
    {
        // validate user exists
        if(userRepository.GetUserByEmail(email) is not User user) {
          
            throw new Exception("user does not exist");
        }
        // validate password if user exists
        if (user.Password != password) {
            throw new Exception("Invalid credentials");
        }
        // create token
        string token = jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return new AuthenticationResult(Guid.NewGuid(), user.FirstName, user.LastName, email, token);
    }
}