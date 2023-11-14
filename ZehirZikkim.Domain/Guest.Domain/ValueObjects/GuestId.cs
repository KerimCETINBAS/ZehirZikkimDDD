using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Guest.Domain.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; }

    private GuestId(Guid value) {
        Value = value;
    }

    public static GuestId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}