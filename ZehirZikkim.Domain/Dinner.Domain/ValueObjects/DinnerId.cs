using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Dinner.Domain.ValueObjects;


public sealed class DinnerId : ValueObject {

    public Guid Value { get; }

    private DinnerId(Guid value) {
        Value = value;
    }

    public static DinnerId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}