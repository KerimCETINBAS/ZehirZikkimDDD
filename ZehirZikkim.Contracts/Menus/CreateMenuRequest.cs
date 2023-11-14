namespace ZehirZikkim.Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSection> Items);

public record MenuSection(
    string Name,
    string Description,
    List<MenuItem> Items);


public record MenuItem (
    string Name, 
    string Description);