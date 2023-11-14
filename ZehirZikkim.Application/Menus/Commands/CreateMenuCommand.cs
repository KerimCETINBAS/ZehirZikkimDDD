
using ErrorOr;
using MediatR;
using ZehirZikkim.Domain.MenuAggregate;
namespace ZehirZikkim.Application.Menus.Commands;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Items): IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemcommand> Items);


public record MenuItemcommand (
    string Name, 
    string Description);