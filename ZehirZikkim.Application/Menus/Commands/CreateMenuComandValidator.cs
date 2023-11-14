using System.Data;

using FluentValidation;

namespace ZehirZikkim.Application.Menus.Commands;

public class CreateMenuCommandValidator: AbstractValidator<CreateMenuCommand> {

    public CreateMenuCommandValidator() {
        RuleFor( x => x.Name).NotEmpty();
        RuleFor( x => x.Description).NotEmpty();
        RuleFor( x => x.Items).NotEmpty();

    }
}