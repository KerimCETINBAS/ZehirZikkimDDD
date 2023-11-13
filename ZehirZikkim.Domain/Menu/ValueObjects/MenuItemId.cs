using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Menu.ValueObjects;


public sealed class MenuItemId : ValueObject {

    public Guid Value { get; }

    private MenuItemId(Guid value) {
        Value = value;
    }

    public static MenuItemId  CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}

