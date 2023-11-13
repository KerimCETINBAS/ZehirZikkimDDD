using FluentValidation;

namespace ZehirZikkim.Application.Auhtentication.Queries.Login;

public class LoginQueryValidator: AbstractValidator<LoginQuery> {

    public LoginQueryValidator() {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}