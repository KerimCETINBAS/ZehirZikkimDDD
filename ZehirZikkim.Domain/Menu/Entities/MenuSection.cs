using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Menu.ValueObjects;

namespace ZehirZikkim.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId> {

    public string Name { get; }

    public string Description { get; }   

    private readonly List<MenuItem> items = new();

    IReadOnlyList<MenuItem> Items => items.AsReadOnly();
    private MenuSection(
        MenuSectionId id,
        string name,
        string description) : base(id) {
            Name = name;
            Description = description;
    }

    public static MenuSection Create(
        string name,
        string description
    ) {
        return new(MenuSectionId.CreateUnique(), name, description);
    }
}