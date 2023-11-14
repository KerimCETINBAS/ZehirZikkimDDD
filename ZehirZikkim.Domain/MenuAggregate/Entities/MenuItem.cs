using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.MenuAggregate.ValueObjects;

namespace ZehirZikkim.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId> {
  

    public string Name { get; }

    public string Description { get; }   


    private MenuItem(MenuItemId id, string name, string description) : base(id) {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description) {
        return new(MenuItemId.CreateUnique(),name, description);
    }
}