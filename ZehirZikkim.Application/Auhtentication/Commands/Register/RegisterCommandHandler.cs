using ErrorOr;
using MediatR;
using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Application.Authentication.Common;
using ZehirZikkim.Domain.Entities;
using ZehirZikkim.Domain.Common.Errors;
namespace ZehirZikkim.Application.Auhtentication.Commands.Register;


public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{


    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {

            await Task.CompletedTask;
             // validate user doesn't exists
            if(userRepository.GetUserByEmail(command.Email) is not null) {
                return Errors.User.EmailConflictException;
            }

            Guid userId = Guid.NewGuid();
            // create a new user (generate unique identifier)
            User user = new()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            userRepository.Add(user);

        


            // create jwt token
            string token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
    }
}