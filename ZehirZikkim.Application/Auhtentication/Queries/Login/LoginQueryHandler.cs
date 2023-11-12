using ErrorOr;
using MediatR;
using ZehirZikkim.Application.Auhtentication.Queries.Login;
using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Application.Authentication.Common;
using ZehirZikkim.Domain.Entities;
using ZehirZikkim.Domain.Common.Errors;
public class LoginQueryHandler :
    IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        this.userRepository = userRepository;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        
        await Task.CompletedTask;
        if(userRepository.GetUserByEmail(command.Email) is not User user) {
          
            return Errors.Auth.CredentialsInvalidException;
        }
        // validate password if user exists
        if (user.Password != command.Password) {
            return Errors.Auth.CredentialsInvalidException;
        }
        // create token
        string token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}