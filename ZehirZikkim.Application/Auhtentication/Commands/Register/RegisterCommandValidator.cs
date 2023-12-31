using FluentValidation;

namespace ZehirZikkim.Application.Auhtentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{

   

    public RegisterCommandValidator()
    {
        RuleFor( x => x.FirstName).NotEmpty();
        RuleFor( x => x.LastName).NotEmpty();
        RuleFor( x => x.Email).EmailAddress(); 
        RuleFor( x => x.Password).NotEmpty();
    }
}