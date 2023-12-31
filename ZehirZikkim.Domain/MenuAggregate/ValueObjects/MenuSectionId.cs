using ZehirZikkim.Domain.Common.Models;
namespace ZehirZikkim.Domain.MenuAggregate.ValueObjects;


public sealed class MenuSectionId : ValueObject {

    public Guid Value { get; }

    private MenuSectionId(Guid value) {
        Value = value;
    }

    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}