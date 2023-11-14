using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.MenuAggregate.ValueObjects;

namespace ZehirZikkim.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId> {

    public string Name { get; }

    public string Description { get; }   

    private readonly List<MenuItem> items = new();

    public IReadOnlyList<MenuItem> Items => items.AsReadOnly();
    private MenuSection(
        MenuSectionId id,
        string name,
        string description,
        List<MenuItem> _menuItems) : base(id) {
            Name = name;
            Description = description;
            items = _menuItems;
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem> menuItems
    ) {
        return new(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
}