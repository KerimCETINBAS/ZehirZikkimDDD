using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Menu.ValueObjects;


public sealed class MenuId : ValueObject {

    public Guid Value { get; }

    private MenuId(Guid value) {
        Value = value;
    }

    public static MenuId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}